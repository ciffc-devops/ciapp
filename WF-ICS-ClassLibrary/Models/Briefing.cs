using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class Briefing : ICloneable
    {
        [ProtoMember(1)] public string TaskNumber { get; set; }
        [ProtoMember(2)] private List<BriefingSection> l_allSections = new List<BriefingSection>();
        [ProtoMember(3)] public int OpPeriod { get; set; }
        [ProtoMember(4)] private Guid _TaskID;
        [ProtoMember(5)] private Guid _BriefingID;
        [ProtoMember(6)] private DateTime _DateCreatedUTC;
        [ProtoMember(7)] private DateTime _DateUpdatedUTC;

        public int OperationalPeriod { get => OpPeriod; set => OpPeriod = value; }
        public List<BriefingSection> AllSections { get { return l_allSections; } set { l_allSections = value; } }
        public string OperationalPeriodWithText { get { return "Operation Period " + OpPeriod.ToString(); } }

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }

        public Guid BriefingID { get => _BriefingID; set => _BriefingID = value; }

        public DateTime DateCreatedUTC { get => _DateCreatedUTC; set => _DateCreatedUTC = value; }

        public DateTime DateUpdatedUTC { get => _DateUpdatedUTC; set => _DateUpdatedUTC = value; }


        public Briefing() { }
        public Briefing(bool loadBlankTemplate)
        {
            if (loadBlankTemplate) { generateBlankBriefing(); }
        }



        public BriefingItem getItemByName(string name)
        {
            BriefingItem bi = new BriefingItem();
            name = name.ToLower();

            foreach (BriefingSection section in AllSections)
            {
                if (section.allItems.Any(o => o.itemName.ToLower() == name))
                {
                    bi = section.allItems.First(o => o.itemName.ToLower() == name);
                }
            }

            return bi;
        }

        public bool ItemByNameHasValue(string name)
        {
            BriefingItem item = getItemByName(name);
            if (item != null) { return !string.IsNullOrEmpty(item.itemValue); }
            else { return false; }
        }

        public int itemsWithContent()
        {
            int items = 0;
            foreach (BriefingSection section in AllSections)
            {
                foreach (BriefingItem item in section.allItems)
                {
                    if (!string.IsNullOrEmpty(item.itemValue)) { items += 1; }
                }
            }
            return items;
        }
        public void loadBriefingSections()
        {
            AllSections.Clear();
            BriefingSection situation = new BriefingSection(); situation.sectionID = new Guid("9aee25ed-7242-4922-90a7-ac906abfff7a"); situation.sortOrder = 1; situation.sectionName = "Situation"; AllSections.Add(situation);
            BriefingSection mission = new BriefingSection(); mission.sectionID = new Guid("440c3692-da5a-49d3-a01c-073d33a4ef1f"); mission.sortOrder = 2; mission.sectionName = "Mission"; AllSections.Add(mission);
            BriefingSection execution = new BriefingSection(); execution.sectionID = new Guid("5f6a9484-9f56-4baa-a1b6-43dacd1fe6b8"); execution.sortOrder = 3; execution.sectionName = "Execution"; AllSections.Add(execution);
            BriefingSection administrationlogistics = new BriefingSection(); administrationlogistics.sectionID = new Guid("6eb4844e-d796-478c-b073-755b947a6994"); administrationlogistics.sortOrder = 4; administrationlogistics.sectionName = "Administration / Logistics"; AllSections.Add(administrationlogistics);
            BriefingSection commandcommunications = new BriefingSection(); commandcommunications.sectionID = new Guid("f901f967-74c9-4a7a-8550-a81e23f6fc0e"); commandcommunications.sortOrder = 5; commandcommunications.sectionName = "Command / Communications"; AllSections.Add(commandcommunications);

        }

        public void generateBlankBriefing()
        {
            loadBriefingSections();

            BriefingSection situation = AllSections.Where(o => o.sectionID == new Guid("9AEE25ED-7242-4922-90A7-AC906ABFFF7A")).First();
            BriefingSection mission = AllSections.Where(o => o.sectionID == new Guid("440C3692-DA5A-49D3-A01C-073D33A4EF1F")).First();
            BriefingSection execution = AllSections.Where(o => o.sectionID == new Guid("5f6a9484-9f56-4baa-a1b6-43dacd1fe6b8")).First();
            BriefingSection administrationlogistics = AllSections.Where(o => o.sectionID == new Guid("6eb4844e-d796-478c-b073-755b947a6994")).First();
            BriefingSection commandcommunications = AllSections.Where(o => o.sectionID == new Guid("f901f967-74c9-4a7a-8550-a81e23f6fc0e")).First();


            //Situation
            BriefingItem _privacyReminder = new BriefingItem("Privacy Reminder", "Incident Management Details", new Guid("d636e7cf-aed6-4f73-8bf5-a08823022d11"), situation.allItems.Count); situation.allItems.Add(_privacyReminder);
            BriefingItem _tasknumber = new BriefingItem("Task Number", "Incident Management Details", new Guid("21E6853D-2819-42AA-8232-5DABD1F3174F"), situation.allItems.Count); situation.allItems.Add(_tasknumber);
            BriefingItem _taskingagencynumber = new BriefingItem("Tasking Agency Number", "Incident Management Details", new Guid("25C10961-AD30-4EDA-B9FE-D9FFFBA12082"), situation.allItems.Count); situation.allItems.Add(_taskingagencynumber);
            BriefingItem _timeofpolicerequest = new BriefingItem("Time of Police Request", "Incident Management Details", new Guid("EE6C2D44-C953-41DC-AED7-A33F3F3B9714"), situation.allItems.Count); situation.allItems.Add(_timeofpolicerequest);
            BriefingItem _timesubjectreportedmissing = new BriefingItem("Time Subject Reported Missing", "Incident Management Details", new Guid("E76A4736-0314-4AF3-9FE5-2F742FD6D4A1"), situation.allItems.Count); situation.allItems.Add(_timesubjectreportedmissing);
            BriefingItem _timeofsarcallout = new BriefingItem("Time of SAR Callout", "Incident Management Details", new Guid("16906250-93EC-466C-A79F-CCFCC0832798"), situation.allItems.Count); situation.allItems.Add(_timeofsarcallout);
            BriefingItem _summaryinforelateddetails = new BriefingItem("Summary info / Related details", "Incident Management Details", new Guid("46DE72BE-ACD6-4F61-AD0F-4D2687E43EA4"), situation.allItems.Count); situation.allItems.Add(_summaryinforelateddetails);

            BriefingItem _firstname = new BriefingItem("First Name", "Subject Information", new Guid("F89CA91A-1122-4FF0-82A4-C783DF5A921D"), situation.allItems.Count); situation.allItems.Add(_firstname);
            BriefingItem _lastname = new BriefingItem("Last Name", "Subject Information", new Guid("A7634E1E-A427-40CF-A9B3-9A0900E3031F"), situation.allItems.Count); situation.allItems.Add(_lastname);
            BriefingItem _knownasnamestocallout = new BriefingItem("Known As / Names to call out (for kids)", "Subject Information", new Guid("47AFCD2E-F6D7-483F-8C6E-271537F2B9D4"), situation.allItems.Count); situation.allItems.Add(_knownasnamestocallout);
            BriefingItem _age = new BriefingItem("Age", "Subject Information", new Guid("1108CA34-A0C2-495C-BA07-D767466EEEEF"), situation.allItems.Count); situation.allItems.Add(_age);
            BriefingItem _sex = new BriefingItem("Sex", "Subject Information", new Guid("A7FA96E5-F62D-4DC3-A518-2ECD114A7D76"), situation.allItems.Count); situation.allItems.Add(_sex);
            BriefingItem _height = new BriefingItem("Height", "Subject Information", new Guid("DF942E5A-3795-4D74-ACD1-372340433089"), situation.allItems.Count); situation.allItems.Add(_height);
            BriefingItem _weight = new BriefingItem("Weight", "Subject Information", new Guid("5E7A19C4-9A52-4F2A-A965-448EA7EB3A64"), situation.allItems.Count); situation.allItems.Add(_weight);
            BriefingItem _complexion = new BriefingItem("Complexion", "Subject Information", new Guid("D5EFFF41-ABCA-4291-8860-1448DD508C63"), situation.allItems.Count); situation.allItems.Add(_complexion);
            BriefingItem _hair = new BriefingItem("Hair", "Subject Information", new Guid("F6A1164D-48B0-4FD7-847A-7BA22C04D071"), situation.allItems.Count); situation.allItems.Add(_hair);
            BriefingItem _eyes = new BriefingItem("Eyes", "Subject Information", new Guid("C3C8D285-E4ED-4DC4-9950-14867F83B834"), situation.allItems.Count); situation.allItems.Add(_eyes);
            BriefingItem _build = new BriefingItem("Build", "Subject Information", new Guid("07D6435F-1A16-4B1D-83FB-057367624EE6"), situation.allItems.Count); situation.allItems.Add(_build);
            BriefingItem _fitness = new BriefingItem("Fitness", "Subject Information", new Guid("4887E22D-5E76-4A2C-995B-34DA6E07328C"), situation.allItems.Count); situation.allItems.Add(_fitness);
            BriefingItem _distinguishingmarks = new BriefingItem("Distinguishing Marks", "Subject Information", new Guid("A71BB490-E9C3-457C-A72A-EFA0373B76FA"), situation.allItems.Count); situation.allItems.Add(_distinguishingmarks);
            BriefingItem _clothingtypescolours = new BriefingItem("Clothing  types / colours", "Subject Information", new Guid("0F1F92DA-5AFD-415C-9CF8-3503A79A6B91"), situation.allItems.Count); situation.allItems.Add(_clothingtypescolours);
            BriefingItem _shoeprintdescription = new BriefingItem("Shoe print description", "Subject Information", new Guid("DCD8A9DD-2CDB-410C-B07B-D8EE1EFCF888"), situation.allItems.Count); situation.allItems.Add(_shoeprintdescription);
            BriefingItem _experiencelevel = new BriefingItem("Experience level", "Subject Information", new Guid("40202A75-9A09-49F1-8E50-656D0DD006BA"), situation.allItems.Count); situation.allItems.Add(_experiencelevel);
            BriefingItem _data = new BriefingItem("Data", "Subject Information", new Guid("E7D842BF-361D-4A88-B050-3C3AF180CB3F"), situation.allItems.Count); situation.allItems.Add(_data);
            BriefingItem _theories = new BriefingItem("Theories", "Subject Information", new Guid("1B897E4C-DF65-4372-B639-41F5C0F39A3D"), situation.allItems.Count); situation.allItems.Add(_theories);
            BriefingItem _plslkplasttimeseen = new BriefingItem("PLS / LKP last time seen", "Subject Information", new Guid("EB2C54D3-F268-4D22-A575-BE37BB096121"), situation.allItems.Count); situation.allItems.Add(_plslkplasttimeseen);
            BriefingItem _circumstancestripplans = new BriefingItem("Circumstances / Trip Plans", "Subject Information", new Guid("0D659262-D096-4C15-A092-25AB04FCC5C0"), situation.allItems.Count); situation.allItems.Add(_circumstancestripplans);
            BriefingItem _equipment = new BriefingItem("Equipment", "Subject Information", new Guid("C7F8FA65-F072-4C40-A7A0-09A899E0D852"), situation.allItems.Count); situation.allItems.Add(_equipment);
            BriefingItem _brandsofcandycigarettesetc = new BriefingItem("Brands of candy / cigarettes etc", "Subject Information", new Guid("5AB34A39-2215-4413-9AB2-DAEE1D1A523B"), situation.allItems.Count); situation.allItems.Add(_brandsofcandycigarettesetc);
            BriefingItem _physicalmedicalmentalconditions = new BriefingItem("Physical/Medical/Mental conditions", "Subject Information", new Guid("7F29DA95-7435-465A-A3D6-DAA0650EF51F"), situation.allItems.Count); situation.allItems.Add(_physicalmedicalmentalconditions);
            BriefingItem _concerns = new BriefingItem("Concerns", "Subject Information", new Guid("F427B51B-3ECA-4C54-8FD6-6F9F943E2080"), situation.allItems.Count); situation.allItems.Add(_concerns);
            BriefingItem _urgencyrating = new BriefingItem("Urgency Rating", "Subject Information", new Guid("FB296D46-870B-4477-B344-1C30C5FF2486"), situation.allItems.Count); situation.allItems.Add(_urgencyrating);
            BriefingItem _handoutsubjectprofile = new BriefingItem("Handout subject profile (ICS301)", "Subject Information", new Guid("ABA9F175-6E13-4CAC-9BE8-BFDC93FE6A4B"), situation.allItems.Count); situation.allItems.Add(_handoutsubjectprofile);

            BriefingItem _mapnumber = new BriefingItem("Map Number", "Map Orientation", new Guid("7c0f5b72-925c-4673-88ec-7bfeeee6d53b"), situation.allItems.Count); situation.allItems.Add(_mapnumber);
            BriefingItem _mapurl = new BriefingItem("Map URL", "Map Orientation", new Guid("8536d309-d946-44ad-9a86-1fe77336c17c"), situation.allItems.Count); situation.allItems.Add(_mapurl);
            BriefingItem _gpsdatumreference = new BriefingItem("GPS datum reference", "Map Orientation", new Guid("4CC16AE1-42CC-4E43-B7D9-6E69A7950049"), situation.allItems.Count); situation.allItems.Add(_gpsdatumreference);
            BriefingItem _magneticdeclination = new BriefingItem("Magnetic Declination", "Map Orientation", new Guid("E4C81281-EFD2-410A-A570-56CBE969DA20"), situation.allItems.Count); situation.allItems.Add(_magneticdeclination);
            BriefingItem _plslpk = new BriefingItem("PLS / LKP (shown on map)", "Map Orientation", new Guid("C949E4B8-D8B0-4125-882F-2EE911235D51"), situation.allItems.Count); situation.allItems.Add(_plslpk);
            BriefingItem _searchareasegments = new BriefingItem("Search area / Segments", "Map Orientation", new Guid("BD39B414-A349-4CC4-AC9D-CCFC63D23E12"), situation.allItems.Count); situation.allItems.Add(_searchareasegments);
            BriefingItem _hazards = new BriefingItem("Hazards", "Map Orientation", new Guid("634D7595-1F7B-40B7-B17D-FCBC245A6196"), situation.allItems.Count); situation.allItems.Add(_hazards);
            BriefingItem _radems = new BriefingItem("General RADeMS Score", "Map Orientation", new Guid("5864ce5f-4cd5-4d35-a401-be98a74d4a8e"), situation.allItems.Count); situation.allItems.Add(_radems);

            BriefingItem _radiorepeaterlocations = new BriefingItem("Radio repeater locations", "Map Orientation", new Guid("0F1DB5E4-D346-4580-9B47-50B2B5C0E79D"), situation.allItems.Count); situation.allItems.Add(_radiorepeaterlocations);
            BriefingItem _physicaldescriptionofsegmentroutearea = new BriefingItem("Physical description of segment / route / area", "Map Orientation", new Guid("0B31887B-BD39-4CBA-AFDE-9BEF3187C9BA"), situation.allItems.Count); situation.allItems.Add(_physicaldescriptionofsegmentroutearea);
            BriefingItem _naturetypeofterrainvegetation = new BriefingItem("Nature / Type of terrain / Vegetation", "Map Orientation", new Guid("3E3CCEAF-D6C2-4223-A0F5-EA78FD5ECC03"), situation.allItems.Count); situation.allItems.Add(_naturetypeofterrainvegetation);
            BriefingItem _physicalboundaries = new BriefingItem("Physical boundaries", "Map Orientation", new Guid("1250155E-6895-4CDA-88A7-64C01985FBAF"), situation.allItems.Count); situation.allItems.Add(_physicalboundaries);
            BriefingItem _prominentgeographicallandmarks = new BriefingItem("Prominent geographical landmarks", "Map Orientation", new Guid("A8AC3492-1C4A-4801-93F6-1DD7CE991E8B"), situation.allItems.Count); situation.allItems.Add(_prominentgeographicallandmarks);
            BriefingItem _altitude = new BriefingItem("Altitude", "Map Orientation", new Guid("FE132257-7B75-41B0-B4E4-8D6B87819BDA"), situation.allItems.Count); situation.allItems.Add(_altitude);
            BriefingItem _exitroutes = new BriefingItem("Exit Routes", "Map Orientation", new Guid("F5D1E5C8-AEC6-4FD2-A396-44B34FDEB514"), situation.allItems.Count); situation.allItems.Add(_exitroutes);
            BriefingItem _locationoficpandotherfacilities = new BriefingItem("Location of ICP and other facilities", "Map Orientation", new Guid("FDC515E1-AD8A-4E21-9BFF-6CDA641D7737"), situation.allItems.Count); situation.allItems.Add(_locationoficpandotherfacilities);

            BriefingItem _digitalMapping = new BriefingItem("Digital Mapping Information", "Map Orientation", new Guid("583fa7a5-714e-447d-b889-46ca3fced345"), situation.allItems.Count); situation.allItems.Add(_digitalMapping);
            BriefingItem _teamTracks = new BriefingItem("Field Team GPS Tracks", "Map Orientation", new Guid("170987aa-11de-445f-8bd2-8b1db172d3a7"), situation.allItems.Count); situation.allItems.Add(_teamTracks);
            BriefingItem _teamPositionTracking = new BriefingItem("Team position tracking info (GPS radio, inreach, mobile app, etc.)", "Map Orientation", new Guid("047e74bd-1691-4e14-9f59-643c37021bb6"), situation.allItems.Count); situation.allItems.Add(_teamPositionTracking);

            BriefingItem _past = new BriefingItem("Past", "Weather", new Guid("BEF83DBA-C22C-431E-B980-F15FBC8F3FBB"), situation.allItems.Count); situation.allItems.Add(_past);
            BriefingItem _current = new BriefingItem("Current", "Weather", new Guid("FE59B7CA-1DDC-441C-9EE1-6C6930A875EB"), situation.allItems.Count); situation.allItems.Add(_current);
            BriefingItem _forecasted = new BriefingItem("Forecasted", "Weather", new Guid("5322FFAC-B926-4E36-945A-11B5986CC466"), situation.allItems.Count); situation.allItems.Add(_forecasted);
            BriefingItem _significanteventsinformation = new BriefingItem("Significant Events / Information", "Significant Events / Information", new Guid("D156CE9A-8961-401A-9D9B-46063A0E3C57"), 53); situation.allItems.Add(_significanteventsinformation);
            BriefingItem _where = new BriefingItem("Where", "Other Search Efforts", new Guid("15B5F8FD-2E45-4340-8BD1-1CEF8213E048"), situation.allItems.Count); situation.allItems.Add(_where);
            BriefingItem _po = new BriefingItem("PO", "Other Search Efforts", new Guid("B56DA61E-B53B-4B33-B37E-6B7B6ADC522E"), situation.allItems.Count); situation.allItems.Add(_po);
            BriefingItem _cluesfound = new BriefingItem("Clues Found", "Other Search Efforts", new Guid("0E600CC0-C223-4148-BC27-7A5002E7307C"), situation.allItems.Count); situation.allItems.Add(_cluesfound);
            BriefingItem _locationofothersearchteams = new BriefingItem("Location of other search teams", "Other Search Support", new Guid("29B61F81-8EAC-4FA4-B7F4-1C447FFB47EB"), situation.allItems.Count); situation.allItems.Add(_locationofothersearchteams);
            BriefingItem _capabilitiesofotherteam = new BriefingItem("Capabilities of other team", "Other Search Support", new Guid("4F1EA86E-5A73-4F14-840D-C459EA346A3C"), situation.allItems.Count); situation.allItems.Add(_capabilitiesofotherteam);

            //Mission
            BriefingItem _mission = new BriefingItem("Mission", "Mission", new Guid("998EB1DE-2F0D-4AA6-A70A-1FB68C424CE3"), mission.allItems.Count); mission.allItems.Add(_mission);

            //Execution
            BriefingItem _phase1 = new BriefingItem("Phase 1 (Preparation)", "Overview", new Guid("232F6DC2-E680-4AAB-80FA-445ED0CC7DBD"), execution.allItems.Count); execution.allItems.Add(_phase1);
            BriefingItem _phase2 = new BriefingItem("Phase 2 (Movement to mission area)", "Overview", new Guid("78175129-CB1C-424A-944E-447CA7DF0081"), execution.allItems.Count); execution.allItems.Add(_phase2);
            BriefingItem _phase3 = new BriefingItem("Phase 3 (Execution)", "Overview", new Guid("688D0E74-C6D3-4504-AF15-7FC60002A16F"), execution.allItems.Count); execution.allItems.Add(_phase3);
            BriefingItem _phase4 = new BriefingItem("Phase 4 (Return to ICP)", "Overview", new Guid("2A1B2E43-ED0F-4DA9-8536-3381B5732FDE"), execution.allItems.Count); execution.allItems.Add(_phase4);
            BriefingItem _phase5 = new BriefingItem("Phase 5 (Post mission actions)", "Overview", new Guid("6DEBC3A2-4B47-48AE-806F-1B6C16EE9D69"), execution.allItems.Count); execution.allItems.Add(_phase5);
            BriefingItem _identifyspecificteammembertasksforeachphase = new BriefingItem("Identify specific team member tasks for each phase", "Specific individual Task by Phase", new Guid("41174AD8-476E-4D04-97A9-D45D28ADEA88"), execution.allItems.Count); execution.allItems.Add(_identifyspecificteammembertasksforeachphase);
            BriefingItem _timings = new BriefingItem("Timings", "Coordinating Details", new Guid("634E0854-D7D5-4351-B49C-561751D9BE91"), execution.allItems.Count); execution.allItems.Add(_timings);
            BriefingItem _movement = new BriefingItem("Movement", "Coordinating Details", new Guid("87E660E1-164F-44FF-A071-10F61DB59B69"), execution.allItems.Count); execution.allItems.Add(_movement);
            BriefingItem _searchtacticinstructions = new BriefingItem("Search tactic instructions", "Coordinating Details", new Guid("F777E91D-CE5B-4CF0-99B1-F8CAD96EE2EC"), execution.allItems.Count); execution.allItems.Add(_searchtacticinstructions);
            BriefingItem _markingflagginginstructions = new BriefingItem("Marking / Flagging instructions", "Coordinating Details", new Guid("D94DAFFA-554B-4C55-9432-86BC6E08C971"), execution.allItems.Count); execution.allItems.Add(_markingflagginginstructions);
            BriefingItem _attractionclues = new BriefingItem("Attraction clues", "Coordinating Details", new Guid("17D99548-366A-47A4-903F-FAC7B9FD8639"), execution.allItems.Count); execution.allItems.Add(_attractionclues);
            BriefingItem _clues = new BriefingItem("Clues", "Coordinating Details", new Guid("AA716DA2-4078-4B95-A8C4-FED590048485"), execution.allItems.Count); execution.allItems.Add(_clues);
            BriefingItem _actiononfindingthesubject = new BriefingItem("Action on finding the subject", "Coordinating Details", new Guid("EE149FB2-1122-4E98-81F8-4C0DE0912119"), execution.allItems.Count); execution.allItems.Add(_actiononfindingthesubject);
            BriefingItem _boundaries = new BriefingItem("Boundaries", "Coordinating Details", new Guid("2BDA73D7-DE63-42FC-85F1-506C0722B557"), execution.allItems.Count); execution.allItems.Add(_boundaries);
            BriefingItem _specialequipment = new BriefingItem("Special Equipment", "Coordinating Details", new Guid("E26F2B85-D244-4D04-BF42-2152A08858A6"), execution.allItems.Count); execution.allItems.Add(_specialequipment);
            BriefingItem _bivouaccamps = new BriefingItem("Bivouac / Camps", "Coordinating Details", new Guid("632E862C-9E41-4708-B8D0-2E46D7434A1F"), execution.allItems.Count); execution.allItems.Add(_bivouaccamps);
            BriefingItem _safety = new BriefingItem("Safety", "Coordinating Details", new Guid("2A31C49C-8BCC-456D-8557-1969DA235F7E"), execution.allItems.Count); execution.allItems.Add(_safety);
            BriefingItem _fireandweatherwatch = new BriefingItem("Fire and weather watch", "Coordinating Details", new Guid("50D9DB6F-8981-4D93-99C2-0D79780F6519"), execution.allItems.Count); execution.allItems.Add(_fireandweatherwatch);
            BriefingItem _debriefing = new BriefingItem("Debriefing", "Coordinating Details", new Guid("48EA7EB8-EC44-4FB1-8727-1388B989A9FC"), execution.allItems.Count); execution.allItems.Add(_debriefing);

            //Admin / Logistics
            BriefingItem _foodwater = new BriefingItem("Food / Water", "Food / Water", new Guid("48F21703-C362-417F-89E0-4E48CD4DED6B"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_foodwater);
            BriefingItem _shelter = new BriefingItem("Shelter", "Shelter", new Guid("2DF285DB-1881-4C51-B215-1BD6E529F5E2"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_shelter);
            BriefingItem _individual = new BriefingItem("Individual", "Equipment / Clothing", new Guid("3E1CD436-EE86-49A0-85CF-52353BCA86F2"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_individual);
            BriefingItem _team = new BriefingItem("Team", "Equipment / Clothing", new Guid("4FFF385E-D5EF-43F4-BCC2-C628C728F5CE"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_team);
            BriefingItem _subject = new BriefingItem("Subject", "Equipment / Clothing", new Guid("F960DC57-06B1-4FFC-BD3B-65B438D7D863"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_subject);
            BriefingItem _safetyequipment = new BriefingItem("Safety Equipment", "Equipment / Clothing", new Guid("413A6E2E-DC72-495A-9F12-F473509FF58B"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_safetyequipment);
            BriefingItem _stores = new BriefingItem("Stores", "Stores", new Guid("2DC8F1E2-742B-4F00-A565-2B7701C791AC"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_stores);
            BriefingItem _transport = new BriefingItem("Transport", "Transport", new Guid("E20459DB-E5EF-48B7-B013-421032D3F2BE"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_transport);
            BriefingItem _rest = new BriefingItem("Rest", "Rest", new Guid("6F91905A-2391-482F-98D3-DEB94762695F"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_rest);
            BriefingItem _medical = new BriefingItem("Medical", "Medical", new Guid("9A3FACBB-4CF6-442A-B876-5C4138442747"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_medical);
            BriefingItem _sanitation = new BriefingItem("Sanitation", "Sanitation", new Guid("F0A2407D-A933-4ED2-9EA8-B93586345D09"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_sanitation);
            BriefingItem _policyoninterviews = new BriefingItem("Policy on Interviews", "Media", new Guid("E5250FBA-FB53-4566-B692-CF59BC6F99F4"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_policyoninterviews);
            BriefingItem _policyonpresenceinarea = new BriefingItem("Policy on presence in area", "Media", new Guid("268BBF60-2705-4FDF-9653-B16574F1867E"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_policyonpresenceinarea);
            BriefingItem _anypresent = new BriefingItem("Any present", "Relatives / Co-workers / Video Cameras", new Guid("DAA6E0BF-6B13-4D52-8121-BD071D0CCE9C"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_anypresent);
            BriefingItem _wherelocatedused = new BriefingItem("Where located / Used", "Relatives / Co-workers / Video Cameras", new Guid("BBB5CBA9-92CD-42CF-BBCF-FAFF6578F072"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_wherelocatedused);
            BriefingItem _warningregardinglanguagejokes = new BriefingItem("Warning regarding language / jokes", "Relatives / Co-workers / Video Cameras", new Guid("1EA44642-F25E-418A-B623-05932D5DF9DB"), administrationlogistics.allItems.Count); administrationlogistics.allItems.Add(_warningregardinglanguagejokes);

            //Command & Comms
            BriefingItem _identifykeyplayers = new BriefingItem("Identify key players", "Command", new Guid("33B07C67-6EA9-4F4B-9652-BF0C8B32B9FC"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_identifykeyplayers);
            BriefingItem _locationoficp = new BriefingItem("Location of ICP", "Command", new Guid("9B8A8885-8E72-4216-A6B9-C71DDD4699FC"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_locationoficp);
            BriefingItem _frequencychannel = new BriefingItem("Frequency / Channel", "Communications", new Guid("0F1E7F7B-8BCA-447D-873A-DED8F8501F98"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_frequencychannel);
            BriefingItem _callsigns = new BriefingItem("Call Signs", "Communications", new Guid("85E35A44-84B1-4534-8F3A-038D726414B0"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_callsigns);
            BriefingItem _codewords = new BriefingItem("Code Words (if applicable)", "Communications", new Guid("50F65EAB-192E-4977-AE2F-4A1D4CD3C07D"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_codewords);
            BriefingItem _radiochecks = new BriefingItem("Radio checks", "Communications", new Guid("893087ED-3B45-4CF7-92C9-6616A481ACC5"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_radiochecks);
            BriefingItem _reports = new BriefingItem("Reports", "Communications", new Guid("BB01DFCF-4729-432A-A21E-7451B1EF0C87"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_reports);
            BriefingItem _synchronizewatches = new BriefingItem("Synchronize Watches", "Synchronize watches", new Guid("0EB363DD-61EA-4B23-A7E8-8D23B370711C"), commandcommunications.allItems.Count); commandcommunications.allItems.Add(_synchronizewatches);
        }
        public bool setValueByFieldID(Guid id, string val)
        {
            if (AllSections.Where(o => o.allItems.Where(i => i.BriefingFieldID == id).Any()).Any())
            {
                BriefingSection section = AllSections.Where(o => o.allItems.Where(i => i.BriefingFieldID == id).Any()).First();
                BriefingItem item = section.allItems.Where(o => o.BriefingFieldID == id).First();
                item.itemValue = val.Trim();
                return true;
            }
            else { return false; }
        }

        public void buildBriefingFromPrevOpPeriod(Briefing prevBriefing)
        {
            foreach (BriefingSection bs in prevBriefing.AllSections)
            {
                BriefingSection newSection = AllSections.Where(o => o.sectionID == bs.sectionID).First();

                foreach (BriefingItem bi in bs.allItems)
                {
                    newSection.allItems.Where(o => o.itemName == bi.itemName).First().itemValue = bi.itemValue;
                }

            }
        }

        public void buildBriefingFromTask(WFIncident task)
        {
            setCmdAndCommsPlanItems(task);
        }

     

        private string addToBriefingField(string currentValue, string valueToAdd)
        {
            if (valueToAdd == null || valueToAdd == "") { return currentValue; }
            else if (currentValue == null || currentValue == "") { return valueToAdd; }
            else { return currentValue + ", " + valueToAdd; }
        }

        private void setCmdAndCommsPlanItems(WFIncident task)
        {
            //fills the briefing with items specific to this task, overriding any template they've saved.
            Guid situationID = new Guid("9aee25ed-7242-4922-90a7-ac906abfff7a");
            Guid commandcommunicationsID = new Guid("f901f967-74c9-4a7a-8550-a81e23f6fc0e");
            AllSections.Where(o => o.sectionID == situationID).First().allItems.Where(o => o.itemName == "Task Number").First().itemValue = task.TaskNumber;
            AllSections.Where(o => o.sectionID == situationID).First().allItems.Where(o => o.itemName == "Tasking Agency Number").First().itemValue = task.AgencyFileNumber;
            //communications


            BriefingItem channelItem = AllSections.Where(o => o.sectionID == commandcommunicationsID).First().allItems.Where(o => o.itemName == "Frequency / Channel").First();
            if (task.PrimaryChannel(OpPeriod).ChannelID != null && task.PrimaryChannel(OpPeriod).ChannelID != "")
            {
                channelItem.itemValue = "Primary Channel: " + task.PrimaryChannel(OpPeriod).IDWithFrequency;
            }
            if (task.SecondaryChannel(OpPeriod).ChannelID != null && task.SecondaryChannel(OpPeriod).ChannelID != "")
            {
                if (channelItem.itemValue != "") { channelItem.itemValue += " | "; }
                channelItem.itemValue += "Secondary Channel: " + task.SecondaryChannel(OpPeriod).IDWithFrequency;
            }
            if (task.Repeater(OpPeriod).ChannelID != null && task.Repeater(OpPeriod).ChannelID != "")
            {
                if (channelItem.itemValue != "") { channelItem.itemValue += " | "; }
                channelItem.itemValue += "Repeater: " + task.Repeater(OpPeriod).IDWithFrequency;
            }
            if (task.EmergencyChannel(OpPeriod).ChannelID != null && task.EmergencyChannel(OpPeriod).ChannelID != "")
            {
                if (channelItem.itemValue != "") { channelItem.itemValue += " | "; }
                channelItem.itemValue += "Emergency Channel: " + task.EmergencyChannel(OpPeriod).IDWithFrequency;
            }
            AllSections.Where(o => o.sectionID == commandcommunicationsID).First().allItems.Where(o => o.itemName == "Call Signs").First().itemValue = "ICP Callsign: " + task.ICPCallSign.ToString();

            //command team
            StringBuilder commandteam = new StringBuilder();
            if (task.allOrgCharts.Where(o => o.OpPeriod == OpPeriod).Any())
            {
                OrganizationChart chart = task.allOrgCharts.Where(o => o.OpPeriod == OpPeriod).First();
                string SARManager = chart.getNameByRoleName("SAR Manager");
                string deputy = chart.getNameByRoleName("Deputy SAR Manager", false);
                string plans = chart.getNameByRoleName("Planning Section Chief", false);
                string ops = chart.getNameByRoleName("Operations Section Chief", false);
                string logistics = chart.getNameByRoleName("Logistics Section Chief", false);
                string safety = chart.getNameByRoleName("Safety Officer", false);

                if (SARManager != null && SARManager != "") { commandteam.Append("Incident Commander: "); commandteam.Append(SARManager); }
                if (deputy != null && deputy != "") { if (commandteam.Length > 0) { commandteam.Append(", "); } commandteam.Append("Deputy Incident Commander: "); commandteam.Append(deputy); }
                if (plans != null && plans != "") { if (commandteam.Length > 0) { commandteam.Append(", "); } commandteam.Append("Plans Chief: "); commandteam.Append(plans); }
                if (ops != null && ops != "") { if (commandteam.Length > 0) { commandteam.Append(", "); } commandteam.Append("Ops Chief: "); commandteam.Append(ops); }
                if (logistics != null && logistics != "") { if (commandteam.Length > 0) { commandteam.Append(", "); } commandteam.Append("Logistics Chief: "); commandteam.Append(logistics); }
                if (safety != null && safety != "") { if (commandteam.Length > 0) { commandteam.Append(", "); } commandteam.Append("Safety Officer: "); commandteam.Append(safety); }
                AllSections.Where(o => o.sectionID == commandcommunicationsID).First().allItems.Where(o => o.itemName == "Identify key players").First().itemValue = commandteam.ToString();

            }

        


            //adds the privacy reminder default text
            Guid PrivacyID = new Guid("d636e7cf-aed6-4f73-8bf5-a08823022d11");
            if (AllSections.Where(o => o.sectionID == situationID).First().allItems.Any(o => o.BriefingFieldID == PrivacyID))
            {
                string DefaultPrivacyText = "Reminder: the contents of this briefing and anything else you learn while involved in this task are private. Please do not share or post any information or photos related to this task on social media without the approval of the incident command team and requesting agency. All documents created on the task are property of the requesting agency.";
                if (string.IsNullOrEmpty(AllSections.Where(o => o.sectionID == situationID).First().allItems.Where(o => o.BriefingFieldID == PrivacyID).First().itemValue))
                {
                    AllSections.Where(o => o.sectionID == situationID).First().allItems.Where(o => o.BriefingFieldID == PrivacyID).First().itemValue = DefaultPrivacyText;
                }
            }
        }

        public Briefing Clone()
        {
            Briefing clone = this.MemberwiseClone() as Briefing;
            clone.AllSections = new List<BriefingSection>();
            foreach (BriefingSection section in AllSections)
            {
                clone.AllSections.Add(section.Clone());
            }

            return clone;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }

    [ProtoContract]
    [Serializable]
    public class BriefingSection : ICloneable
    {
        [ProtoMember(1)]
        public Guid sectionID { get; set; }
        [ProtoMember(2)]
        public string sectionName { get; set; }
        [ProtoMember(3)]
        public int sortOrder { get; set; }
        [ProtoMember(4)]
        private List<BriefingItem> l_allItems = new List<BriefingItem>();
        public List<BriefingItem> allItems { get { return l_allItems; } set { l_allItems = value; } }

        public BriefingSection Clone()
        {
            BriefingSection cloneTo = new BriefingSection();
            cloneTo.sectionID = sectionID;
            cloneTo.sectionName = sectionName;
            cloneTo.sortOrder = sortOrder;
            foreach (BriefingItem item in allItems)
            {
                cloneTo.allItems.Add(item.Clone());
            }


            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    [ProtoContract]
    [Serializable]
    public class BriefingItem : ICloneable
    {
        public BriefingItem() { }
        public BriefingItem(string name, string sub_section, Guid id, int sort) { itemName = name; subSectionName = sub_section; BriefingFieldID = id; FieldSort = sort; }
        [ProtoMember(1)] public string itemName { get; set; }
        [ProtoMember(2)] public string itemValue { get; set; }
        [ProtoMember(3)] public string subSectionName { get; set; }
        [ProtoMember(4)] private Guid _BriefingValueID;

        [ProtoMember(5)] private Guid _BriefingFieldID;

        [ProtoMember(6)] private Guid _BriefingSectionID;

        [ProtoMember(7)] private int _FieldSort;

        [ProtoMember(8)] private Guid _BriefingID;


        public Guid BriefingValueID { get => _BriefingValueID; set => _BriefingValueID = value; }
        public Guid BriefingFieldID { get => _BriefingFieldID; set => _BriefingFieldID = value; }
        public Guid BriefingSectionID { get => _BriefingSectionID; set => _BriefingSectionID = value; }
        public int FieldSort { get => _FieldSort; set => _FieldSort = value; }
        public Guid BriefingID { get => _BriefingID; set => _BriefingID = value; }

        public BriefingItem Clone()
        {
            return this.MemberwiseClone() as BriefingItem;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
