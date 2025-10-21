using System.Collections.Generic;
using System.Linq.Expressions;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{
    

    public static class ICSFormTools
    {
        public static readonly string[] ICSFormNumbers = new string[] { "201", "202", "203", "203A", "204AH", "204WF", "205", "205A", "206", "207", "208", "209", "209WF", "210", "211", "213", "213RR", "214", "215", "215a", "216", "217", "218", "219", "220", "221", "224", "225", "230", "232", "233", "234", "259", "260", "309" };
        public static readonly string[] ICSFormNumbersInCiapp = new string[] { "202", "203",  "204WF", "205", "205A", "206", "207", "208", "209",  "211", "213", "214",  "218", "220", "221" };

        public static List<ICSFormInformation> GetAllForms(bool onlyInCiapp = true)
        {
            List<ICSFormInformation> forms = new List<ICSFormInformation>();
            string[] formNumbers = onlyInCiapp ? ICSFormNumbersInCiapp : ICSFormNumbers;
            foreach (string formNumber in formNumbers)
            {
                ICSFormInformation form = GetFormByNumber(formNumber);
                if (form.FormNumber != 0)
                {
                    forms.Add(form);
                }
            }
            return forms;
        }

        public static ICSFormInformation GetFormByNumber(string number)
        {
            ICSFormInformation form = new ICSFormInformation();

            switch (number)
            {

                case "201": form = new ICSFormInformation() { FormNumber = 201, FormName = "Incident Briefing", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/201-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-201.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "202": form = new ICSFormInformation() { FormNumber = 202, FormName = "Incident Objectives", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/202-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-202.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-202-WF-Incident-Objectives.pdf" }; break;
                case "203": form = new ICSFormInformation() { FormNumber = 203, FormName = "Organization Assignment List ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/203-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-203.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-203 Organization Assignment List Blanked.pdf" }; break;
                case "203A": form = new ICSFormInformation() { FormNumber = 203, FormName = "Organizational Assignment List Attachment", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "A", FileName = "" }; break;
                case "204AH": form = new ICSFormInformation() { FormNumber = 204, FormName = "Assignment List", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/204-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-204.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "AH", FileName = "" }; break;
                case "204WF": form = new ICSFormInformation() { FormNumber = 204, FormName = "Assignment List - Wildfire", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "WF", FileName = "ICS-204-WF Assignment List.pdf" }; break;
                case "205": form = new ICSFormInformation() { FormNumber = 205, FormName = "Radio Communications Plan", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/205-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-205.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS205WF-Communications-Plan.pdf" }; break;
                case "205A": form = new ICSFormInformation() { FormNumber = 205, FormName = "Communications List", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/205-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "A", FileName = "ICS205A-CommunicationsList.pdf" }; break;
                case "206": form = new ICSFormInformation() { FormNumber = 206, FormName = "Medical Plan", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/206-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-206.mp4", Purpose = "The Medical Plan (ICS 206) provides information on incident medical aid stations, transportation services, hospitals, and medical emergency procedures.", Preparation = "The ICS 206 is prepared by the Medical Unit Leader and reviewed by the Safety Officer to ensure ICS coordination. If aviation assets are utilized for rescue, coordinate with Air Operations.", Distribution = "The ICS 206 is duplicated and attached to the Incident Objectives (ICS 202) and given to all recipients as part of the Incident Action Plan (IAP). Information from the plan pertaining to incident medical aid stations and medical emergency procedures may be noted on the Assignment List (ICS 204). All completed original forms must be given to the Documentation Unit.", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-206-WF-Medical-Plan.pdf" }; break;
                case "207": form = new ICSFormInformation() { FormNumber = 207, FormName = "Organization Chart ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/207-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "ICS-207-WF Incident Organization Chart.pdf" }; break;
                case "208": form = new ICSFormInformation() { FormNumber = 208, FormName = "Safety Message/Plan", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/208-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-208.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-208-WF-Safety-Message.pdf" }; break;
                case "209": form = new ICSFormInformation() { FormNumber = 209, FormName = "Incident Status Summary", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/209-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-209.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "Form-209.pdf" }; break;
                case "209WF": form = new ICSFormInformation() { FormNumber = 209, FormName = "Incident Status Summary  - Wildfire", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "WF", FileName = "" }; break;
                case "210": form = new ICSFormInformation() { FormNumber = 210, FormName = "Resource Status Change Form ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/210-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-210.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "211": form = new ICSFormInformation() { FormNumber = 211, FormName = "Check In ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/211-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-211.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "ICS-211-WF Check In.pd" }; break;
                case "213": form = new ICSFormInformation() { FormNumber = 213, FormName = "General Message ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/213-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/10/ICS-Form-213.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "ICS-213-WF-General-Message.pdf" }; break;
                case "213RR": form = new ICSFormInformation() { FormNumber = 213, FormName = "Resource Request", InstructionsURL = "", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-213RR.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "RR", FileName = "" }; break;
                case "214": form = new ICSFormInformation() { FormNumber = 214, FormName = "Activity Log", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/214-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-214.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-214-WF-Activity-Log.pdf" }; break;
                case "215": form = new ICSFormInformation() { FormNumber = 215, FormName = "Operational Planning Worksheet ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/215-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-215.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "215a": form = new ICSFormInformation() { FormNumber = 215, FormName = "Incident Action Plan Safety Analysis ", InstructionsURL = "", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-215A.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "a", FileName = "" }; break;
                case "216": form = new ICSFormInformation() { FormNumber = 216, FormName = "Radio Requirements Worksheet ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/216-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "217": form = new ICSFormInformation() { FormNumber = 217, FormName = "Communications Resource Availability", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/217-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "218": form = new ICSFormInformation() { FormNumber = 218, FormName = "Support Vehicle Inventory ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/218-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-218.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "219": form = new ICSFormInformation() { FormNumber = 219, FormName = "T-Card Package ", InstructionsURL = "", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-219.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "220": form = new ICSFormInformation() { FormNumber = 220, FormName = "Air Operations Summary", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/220-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = true, FormNumberModifier = "", FileName = "ICS-220-WF Air Operations Summary.pdf" }; break;
                case "221": form = new ICSFormInformation() { FormNumber = 221, FormName = "Demobilization/Checkout ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/221-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-221.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "ICS-221-WF Demobilization Checkout.pdf" }; break;
                case "224": form = new ICSFormInformation() { FormNumber = 224, FormName = "Crew Performance Rating", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/224-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "225": form = new ICSFormInformation() { FormNumber = 225, FormName = "Incident Personnel Performance Rating", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/225-Instructions.pdf", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-225.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "230": form = new ICSFormInformation() { FormNumber = 230, FormName = "Daily Meeting Schedule ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/230-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "232": form = new ICSFormInformation() { FormNumber = 232, FormName = "Resources at Risk Summary ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/232-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "233": form = new ICSFormInformation() { FormNumber = 233, FormName = "Incident Open Action Tracker ", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "234": form = new ICSFormInformation() { FormNumber = 234, FormName = "Work Analysis Matrix ", InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/234-Instructions.pdf", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "259": form = new ICSFormInformation() { FormNumber = 259, FormName = "Resource Order Forms Package (Aircraft, Overhead, Crews, Supplies, Equipment)", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "260": form = new ICSFormInformation() { FormNumber = 260, FormName = "Resource Order Form (Generic)", InstructionsURL = "", VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-260.mp4", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;
                case "309": form = new ICSFormInformation() { FormNumber = 309, FormName = "Communications Log", InstructionsURL = "", VideoURL = "", Purpose = "", Preparation = "", Distribution = "", IsInIAP = false, FormNumberModifier = "", FileName = "" }; break;

            }


            if (form.FormNumber != 0)
            {
                form.Fields = GetFields(form.FormNumberWithModifier);
            }
            return form;

        }

        public static List<ICSFormField> GetFields(string formNumber)
        {
            List<ICSFormField> fields = new List<ICSFormField>();

            switch (formNumber)
            {
                case "206":
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 1, FieldName = "Incident Name", Instructions = "Enter the name assigned to the incident." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 2, FieldName = "Date I Time Prepared", Instructions = "Enter the date the plan was prepared. A medical plan could remain unchanged throughout the duration of the incident.  Enter the time (24-hour clock) plan was prepared." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 3, FieldName = "Operational Period", Instructions = "Enter the start date (month/day/year) and time (using the 24-hour clock) and end date and time for the operational period to which the form applies." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 4, FieldName = "Incident Medical Aid", Instructions = "Enter the following information on the incident medical aid station(s):\nName - Enter name of the medical aid station.\nLocation - Enter the location of the medical aid station (e.g., Staging Area, Camp Ground).\nParamedics on Site? - Indicate (yes or no) if paramedics are at the site indicated." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 5, FieldName = "Transportation (indicate air or ground)", Instructions = "Enter the following information for ambulance services available to the incident:\nAmbulance Service - Enter name of ambulance service.\nLocation - Enter the location of the ambulance service.\nContact Number(s)/Frequency - Enter the contact number(s) and frequency for the ambulance service.\nLevel of Service - Indicate the level of service available for each ambulance, either ALS (Advanced Life Support) or BLS (Basic Life Support)." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 6, FieldName = "Hospitals", Instructions = "Enter the following information for hospital(s) that could serve this incident:\nHospital Name - Enter hospital name and identify any predesignated medivac aircraft by name a frequency.\nAddress, Latitude & Longitude - Enter the physical address of the hospital and the latitude and longitude if the hospital has a helipad.\nTravel Time - Enter the travel time by air and ground from the incident to the hospital.\nContact Number(s)/ Frequency - Enter the contact number(s) and/or communications frequency(s) for the hospital.\nHelipad - Indicate if the hospital has a helipad. Latitude and Longitude - data format need to compliment Medical\nBurn Center - Indicate (yes or no) if the hospital has a burn center." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 7, FieldName = "Special Medical Emergency Procedures", Instructions = "Note any special emergency instructions for use by incident personnel, including (1) who should be contacted, (2) how should they be contacted; and (3) who manages an incident within an incident due to a rescue, accident, etc. Include procedures for how to report medical emergencies." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 8, FieldName = "Prepared by (Medical Unit Leader)", Instructions = "Enter the name and signature of the person preparing the form, typically the Medical Unit Leader. Enter date (month/day/year) and time prepared (24-hour clock)." });
                    fields.Add(new ICSFormField { FormNumber = 206, FieldNumber = 9, FieldName = "Approved by (Safety Officer)", Instructions = "Enter the name of the person who approved the plan, typically the Safety Officer. Enter date (month/day/year) and time reviewed (24-hour clock)." });
                    break;
            }
                


            return fields;
        }
    }
}
