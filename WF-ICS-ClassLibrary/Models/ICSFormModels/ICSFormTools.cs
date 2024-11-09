using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{
    public static class ICSFormTools
    {
        public static ICSFormInformation GetFormByNumber(int number)
        {
            ICSFormInformation form = new ICSFormInformation();

            switch (number)
            {
                case 206:
                    form.FormName = "Medical Plan";
                    form.FormNumber = 206;
                    form.InstructionsURL = "https://icscanada.ca/wp-content/uploads/2023/11/206-Instructions.pdf";
                    form.VideoURL = "https://icscanada.ca/wp-content/uploads/2024/09/ICS-Form-206.mp4";
                    form.Purpose = "The Medical Plan (ICS 206) provides information on incident medical aid stations, transportation services, hospitals, and medical emergency procedures.";
                    form.Preparation = "The ICS 206 is prepared by the Medical Unit Leader and reviewed by the Safety Officer to ensure ICS coordination. If aviation assets are utilized for rescue, coordinate with Air Operations.";
                    form.Distribution = "The ICS 206 is duplicated and attached to the Incident Objectives (ICS 202) and given to all recipients as part of the Incident Action Plan (IAP). Information from the plan pertaining to incident medical aid stations and medical emergency procedures may be noted on the Assignment List (ICS 204). All completed original forms must be given to the Documentation Unit.";
                    form.IsInIAP = true;
                    
                    break;
            }

            if (form.FormNumber != 0)
            {
                form.Fields = GetFields(form.FormNumber);
            }
            return form;

        }

        public static List<ICSFormField> GetFields(int formNumber)
        {
            List<ICSFormField> fields = new List<ICSFormField>();

            switch (formNumber)
            {
                case 206:
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
