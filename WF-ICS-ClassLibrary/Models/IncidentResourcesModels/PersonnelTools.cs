using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    public static class PersonnelTools
    {

        public static List<string> GetPersonnelKinds()
        {
            List<string> kinds = new List<string>();
            kinds.Add("IMT - Command/General Staff/Unit Leaders/Managers");
            kinds.Add("Single Resource");
            kinds.Add("Structure Protection Specialist - STPS");
            kinds.Add("Wildland Urban Interface Crew Boss - WUIB");
            kinds.Add("Wildland Urban Interface STLD ");
            kinds.Add("Wildland Urban Interface TFLD");
            kinds.Add("Wildland Urban Interface Crew Member");
            kinds.Add("Contractor");
            kinds.Add("Unit Crew Member");
            kinds.Add("Unit Crew Leader");
            kinds.Add("Unit Crew Sub-Leader");
            kinds.Add("Initial Attack Crew Member");
            kinds.Add("Initial Attack Crew Leader");
            kinds.Add("Sustained Action Crew Member");
            kinds.Add("Sustained Action Crew Leader");


            return kinds;
        }
        public static string ExportSignInRecordsToCSV(this Incident incident, List<MemberStatus> records, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            //header row
            csv.Append("NAME"); csv.Append(delimiter);
            csv.Append("PROVINCE OR TERRITORY"); csv.Append(delimiter);
            csv.Append("AGENCY"); csv.Append(delimiter);
            
            csv.Append("CHECK IN"); csv.Append(delimiter);
            csv.Append("LDW"); csv.Append(delimiter);
            csv.Append("DEPARTURE POINT"); csv.Append(delimiter);
            csv.Append("METHOD OF TRAVEL"); csv.Append(delimiter);
            csv.Append("CHECK OUT"); csv.Append(delimiter);
           

            csv.Append(Environment.NewLine);
            foreach (MemberStatus status in records.OrderBy(o => o.MemberName))
            {
                CheckInRecord rec  = new CheckInRecord();
                if (incident.AllCheckInRecords.Any(o => o.ResourceID == status.MemberID))
                {
                   rec = incident.AllCheckInRecords.Where(o => o.ResourceID == status.MemberID).First();
                }

                /*
                csv.Append("\""); csv.Append(status.MemberName.EscapeQuotes()); csv.Append("\"");
                csv.Append(delimiter);
                if (rec != null) { csv.Append(rec.teamMember.ProvinceNameShort.EscapeQuotes()); }
                csv.Append(delimiter);
                csv.Append("\""); csv.Append(status.OrganizationName.EscapeQuotes()); csv.Append("\"");
                csv.Append(delimiter);
               
                csv.Append(status.SignInTime.ToString(Globals.DateFormat + " HH:mm"));
                csv.Append(delimiter);
                csv.Append(status.LastDayWorked.ToString(Globals.DateFormat + " HH:mm"));
                csv.Append(delimiter);
                if (rec != null) { csv.Append("\""); csv.Append(rec.DeparturePoint.EscapeQuotes()); csv.Append("\""); }
                csv.Append(delimiter);
                if (rec != null) { csv.Append("\""); csv.Append(rec.MethodOfTravel.EscapeQuotes()); csv.Append("\""); }
                csv.Append(delimiter);
                */

                csv.Append(status.SignOutTimeOrBlank);
               
                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

        public static List<AgencyPersonnelCount> GetAgencyPersonnelCount(this Incident incident, int OpPeriod)
        {
            List<AgencyPersonnelCount> counts = new List<AgencyPersonnelCount>();

            foreach (CheckInRecord record in incident.AllCheckInRecords.Where(o => o.OpPeriod == OpPeriod && o.Active && (o.IsPerson || o.IsVisitor)))
            {
                if (incident.IncidentPersonnel.Any(o => o.ID == record.ResourceID))
                {
                    Personnel per = incident.IncidentPersonnel.First(o => o.ID == record.ResourceID);
                    if (!counts.Any(o => o.AgencyName.Equals(per.Agency)))
                    {
                        AgencyPersonnelCount c = new AgencyPersonnelCount();
                        c.AgencyName = per.Agency;
                        c.Count = 0;
                        counts.Add(c);
                    }
                    counts.First(o => o.AgencyName.Equals(per.Agency)).Count++;
                }
            }
            return counts;
        }


        public static string ToCSV(this List<Personnel> members, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("First Name"); csv.Append(delimiter);
            csv.Append("Middle Initial"); csv.Append(delimiter);
            csv.Append("Last Name"); csv.Append(delimiter);
            csv.Append("Pronouns"); csv.Append(delimiter);
            csv.Append("Kind"); csv.Append(delimiter);
            csv.Append("Type"); csv.Append(delimiter);
            csv.Append("Accomodatoin Preference"); csv.Append(delimiter);
            csv.Append("Province or Territory"); csv.Append(delimiter);
            csv.Append("Country"); csv.Append(delimiter);
            csv.Append("Agency"); csv.Append(delimiter);
            csv.Append("Phone"); csv.Append(delimiter);
            csv.Append("Callsign"); csv.Append(delimiter);
            csv.Append("Email"); csv.Append(delimiter);
            csv.Append("Home Unit / Agency"); csv.Append(delimiter);
            csv.Append("Dietary Restrictions"); csv.Append(delimiter);
            csv.Append("Allergies"); csv.Append(delimiter);
            csv.Append("Employer Emergency Contact"); csv.Append(delimiter);
            
            csv.Append(Environment.NewLine);

            foreach (Personnel item in members)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 

                csv.Append("\""); csv.Append(item.FirstName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.MiddleInitial.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.LastName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Pronouns.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Kind.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Type.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.AccommodationPreference.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                if (item.HomeProvinceID != Guid.Empty) { Province p = new Province(item.HomeProvinceID); csv.Append("\""); csv.Append(p.ProvinceName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter); }
                else { csv.Append("\"");  csv.Append("\""); csv.Append(delimiter); }

                csv.Append("\""); csv.Append(item.HomeCountry.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Agency.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.CellphoneNumber.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.CallSign.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Email.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HomeUnit.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HasDietaryRestrictions.ToString()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HasAllergies.ToString()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.EmergencyContact.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);


                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

    }

}
