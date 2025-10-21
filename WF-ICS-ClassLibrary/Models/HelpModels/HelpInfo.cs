using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class HelpInfo
    {
        private string _ID;
        private string _Title;
        private string _Body;
        private string _moreInfoURL;
        private string _moreInfoButtonText;

        public HelpInfo() { }
        public HelpInfo(string title, string body) { Title = title; Body = body; }

        public string ID { get => _ID; set => _ID = value; }
        public string Title { get => _Title; set => _Title = value; }
        public string Body { get => _Body; set => _Body = value; }
        public string MoreInfoURL { get => _moreInfoURL; set => _moreInfoURL = value; }
        public string MoreInfoButtonText { get => _moreInfoButtonText; set => _moreInfoButtonText = value; }
        public bool loadByTopic(string id)
        {
            StringBuilder bt = new StringBuilder();
            ID = id;
            switch (id)
            {
                case "RestoreDeleted":
                    Title = "Restore Deleted Items";
                    bt.Append("This tool allows you to review and restore previously deleted items from within the task. Any items you opt to restore will re-appear in their original location, and be re-transmitted via the network and internet sync.");
                    Body = bt.ToString();
                    return true;
                case "TeamAssignmentTemplate":
                    Title = "Use Assignment Template";
                    Body = "This tool allows you to use a pre-written assignment template. Clicking on the Use Template button will overwrite the assignment name, tactical assignment, and special instructions with pre-written information.  You will have a chance to edit this after applying the template as needed.";
                    return true;

                /* newly added for WF */
                case "IncidentObjectives":
                    Title = "Incident Objectives";
                    bt.Append("Enter clear, concise statements of the objectives for managing the response. Ideally, these objectives will be listed in priority order. These objectives are for the incident response for this operational period as well as for the duration of the incident."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Include alternative and/or specific tactical objectives as applicable. Objectives should follow the SMART model or a similar approach:"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);

                    bt.Append("S pecific - Is the wording precise and unambiguous?"); bt.Append(Environment.NewLine); 
                    bt.Append("M easurable - How will achievements be measured?"); bt.Append(Environment.NewLine); 
                    bt.Append("A ction-oriented - Is an action verb used to describe expected accomplishments?"); bt.Append(Environment.NewLine); 
                    bt.Append("R ealistic - Is the outcome achievable with given available resources?"); bt.Append(Environment.NewLine); 
                    bt.Append("T ime-sensitive - What is the timeframe?"); bt.Append(Environment.NewLine); 


                    Body = bt.ToString();
                    return true;
                case "GeneralMessage":
                    Title = "General Message";
                    bt.Append("Purpose. The General Message (ICS 213) is used by the incident dispatchers to record incoming messages that cannot be orally transmitted to the intended recipients. The ICS 213 is also used by the Incident Command Post and other incident personnel to transmit messages (e.g., resource order, incident name change, other ICS coordination issues, etc.) to the Incident Communications Center for transmission via radio or telephone to the addressee. This form is used to send any message or notification to incident personnel that requires hard-copy delivery."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);

                    bt.Append("Preparation. The ICS 213 may be initiated by incident dispatchers and any other personnel on an incident."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);

                    bt.Append("Distribution. Upon completion, the ICS 213 may be delivered to the addressee and/or delivered to the Incident Communication Center for transmission."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);

                    bt.Append("Notes:"); bt.Append(Environment.NewLine);
                    bt.Append("• The ICS 213 is a three-part form, typically using carbon paper or can be created in booklets using carbon-less paper. The sender will complete Part 1 of the form and send Parts 2 and 3 to the recipient. The recipient will complete Part 2 and return Part 3 to the sender."); bt.Append(Environment.NewLine);
                    bt.Append("• A copy of the ICS 213 should be sent to and maintained within the Documentation Unit."); bt.Append(Environment.NewLine);
                    bt.Append("• Contact information for the sender and receiver can be added for communications purposes to confirm resource orders."); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;

                case "CommsForAir":
                    Title = "Used for Aircraft";
                    bt.Append("If this box is checked, this item will be included in the '7. FREQUENCIES' section of ICS-220 Air Ops Summary."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;


                case "AircraftIsMedivac":
                    Title = "Aircraft used for medivac";
                    Body = "If checked, this aircraft's information will be summarized in the Medivac field (4) on the Air Operations Summary form.";
                    return true;
                /* Member import */
                case "CSV":
                    Title = "Comma Separated Values required";
                    bt.Append("You must select a Comma Separated Values file (.csv), which is a very simple form of spreadsheet. It should be available as an option when saving files in Excel or other spreadsheet programs. ");
                    Body = bt.ToString();
                    return true;
                case "MemberImportColumns":
                    Title = "Import Columns";
                    bt.Append("Use the dropdown boxes to select the appropriate column in your file where each piece of information is found.  If there is a piece of information not covered in your file, select a column that you know will be blank.  For example, if your file has no “Phone Number” column, select an unused column such as “AA”."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For the “Vegetarian” and “No Gluten” items, your spreadsheet should have “Yes”, “Y”, or “1” to indicate a positive.  For example, someone who is vegetarian and gluten intolerant would have “y” and “y” in those two columns for their row.");
                    
                    Body = bt.ToString();
                    return true;
                case "UpdateExisting":
                    Title = "Update Existing Members";
                    bt.Append("If you select “Update existing members”, the system will try to update someone already in your list rather than adding a new person.  If an individual in your spreadsheet has the same name as someone already in your system, and their phone number, email address, or agency match, the system will assume they’re the same individual.");
                    Body= bt.ToString();
                    return true;
                case "DefaultProvAgency":
                    Title = "Default Agency and Province/Territory";
                    bt.Append("The default Agency and Province/Territory specified here will be used when importing members from a spreadsheet when no agency or province/territory is found in the sheet.");
                    Body = bt.ToString();
                    return true;


                case "UniqueResourceNumbers":
                    Title = "Unique resource numbering";
                    bt.Append("This system will attempt to assign a unique identifier to each resource that is checked in.  For personnel, crew members, visitors, and equipment operators this will be a “P Number”, for vehicles a “V Number”, for equipment an “E Number” and lastly for crews a “C Number”."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If all devices doing check-ins are connected to one another via local area network, the system should run fine with no extra steps required."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If you have computers connected via internet, or who are offsite and working remotely, you’ll need to allocate blocks of numbers to those machines for them to use.  In that case, follow this procedure:"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("1. Select the block of numbers to be used by the remote machine for personnel, vehicles, equipment, and crews.  For example, give them 700-900."); bt.Append(Environment.NewLine); 
                    bt.Append("2. On the primary system, set the upper and lower values to avoid that range.  In the example above, set it to 1-699."); bt.Append(Environment.NewLine); 
                    bt.Append("3. On the remote system, set the upper and lower values to the numbers selected. In that example, set the lower bound to 700 and the upper top 900."); bt.Append(Environment.NewLine); 
                    bt.Append("4. When a system runs out of available numbers for a category, you will be alerted."); bt.Append(Environment.NewLine);
                    bt.Append("5. It is possible that your primary system will use all available numbers between 1 and the start of the block you’ve given to the remote system.  When that happens, just set the lower bound to 1 higher than the block given and the upper bound to 10,000.  In the example, above, set the lower to 901 and the upper to 10,000.");
                    Body = bt.ToString();
                    return true;



                /* SAR Sign-In Assist Items */
                case "SignInAssist-Activity":
                    Title = "Current Activity";
                    bt.Append("By setting the 'Current Activity' you will be able to easily review the sign in records relevant to the activity."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("In the list of sign-ins below the first column will show the activity name used when the user signed in."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For accuracy and space, it is recommended you use the task number (e.g. 12345) as the activity name for sar tasks, but it is not required."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;

                case "ShiftBriefingAdditionalInfo":
                    Title = "Shift Briefing Additional Info";
                    bt.Append("If you elect to include additional info with this shift briefing, a copy of the general SMEAC briefing for the op period, and any subject profiles, will be automatically added to the shfit briefing PDF."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;

                /* D4H Import */
                case "D4HQualificationImport":
                    Title = "D4H Qualification Import";
                    bt.Append("Getting the File"); bt.Append(Environment.NewLine);
                    bt.Append(""); bt.Append(Environment.NewLine);
                    bt.Append("In order to get the appropriate file from D4H, follow these instructions:"); bt.Append(Environment.NewLine);
                    bt.Append("1. Sign into your D4H account as a Member+ or higher-level user"); bt.Append(Environment.NewLine);
                    bt.Append("2. Go to the main Qualifications page (Planning > Qualifications)"); bt.Append(Environment.NewLine);
                    bt.Append("3. On the right-hand side, look for the \"Export\" panel"); bt.Append(Environment.NewLine);
                    bt.Append("4. Click the \"Matrix\" link.  This should download a CSV file called XXXXX__courses_matrix.csv"); bt.Append(Environment.NewLine);
                    bt.Append("5. Notice where it has been saved (likely your Downloads folder)"); bt.Append(Environment.NewLine);
                    bt.Append(""); bt.Append(Environment.NewLine);
                    bt.Append("*if you do not have the Export panel or the Matrix option, verify you have a high enough permission level in d4h."); bt.Append(Environment.NewLine);
                    bt.Append(""); bt.Append(Environment.NewLine);
                    bt.Append("Limitations"); bt.Append(Environment.NewLine);
                    bt.Append(""); bt.Append(Environment.NewLine);
                    bt.Append("First, this import process will only add new qualifications, it will not remove previously entered qualifications.  This is by design, as it prevents custom changes from being overwritten unintentionally."); bt.Append(Environment.NewLine);
                    bt.Append("Second, only the provincially-created qualifications are used.  It will not reference any qualifications you have created in your own group’s account."); bt.Append(Environment.NewLine);
                    bt.Append("Third, for Rope Rescue, only the modern “Tech 1” and “Tech 2” qualifications are used."); bt.Append(Environment.NewLine);
                    bt.Append("Fourth, it will not attempt to import “first aid” status, as there will be a wide range of use cases.  Some groups may tick the box for any user with minimum first aid, others may only tick it for higher level first aid."); bt.Append(Environment.NewLine);

                    Body = bt.ToString();
                    return true;
                /* Statistics */
                case "AssignmentDuration":
                    Title = "Assignment Duration";
                    bt.Append("Assignment duration is estimated using a number of factors."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For an area search, the area of the assignment, the spacing between members, the speed of those members, and the number of members are all factored in to estimate duration."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For a linear assignment, the length of the route and the movement speed are used to estimate duration.  Number of members and spacing is not relevant, since all members will be walking along the same route or trail. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For a corridor (aka buffer) search, use the Area Assignment section instead.");
                    Body = bt.ToString();
                    return true;
                case "POD":
                    Title = "Probability of Detection";
                    bt.Append("The probability of detection (POD) is defined as the conditional probability that the search object will be detected during a single search assignment if the search object is present in the area during the search."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("In simple terms, it is the likelihood that a team will spot the subject in the area, assuming they are there.For a visual search, this is typically based on the spacing between the team members, the range of detection, and the visibility of the subject."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It is very typical that a visual search assignment will have a POD of about 63 %, and virtually impossible to have one over 86 % from a single search of an area.");
                    Body = bt.ToString();
                    return true;
                case "TrackSpacing":
                    Title = "Spacing";
                    bt.Append("This is the distance between searchers, sometimes referred to as ‘track spacing’ used for a visual sweep.Ideally, it will be based on a range of detection determined either through an in-field test or pre - existing information for the terrain.  Spacing, and its relationship to the range of detection and subject visibility, is used to calculate the Probability of Detection for a visual sweep."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If you would like to use the correct spacing for a 63 % POD, use the “Calculate spacing” button.The program will consult a pre - set table and provide the appropriate spacing for you.");
                    Body = bt.ToString();
                    return true;
                case "SubjectVisibility":
                    Title = "Subject Visibility";
                    bt.Append("When using Range of Detection to calculate team spacing, it is important to select the correct option for subject visibility.  You can use the values below as a guideline:"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("High Visibility – this would be an adult subject who is wearing bright clothing, is likely to respond if called, or may attempt to signal searchers if they are nearby."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Medium Visibility – Good for general use, full sized, non - evasive subjects."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Low Visibility – Smaller articles, smaller subjects(children), or subjects who may be either evasive or attempting to hide.Consider this option for despondent subjects, children, and any other profile that suggests evasiveness.");
                    Body = bt.ToString();
                    return true;
                case "RangeOfDetection":
                    Title = "Range of Detection";
                    bt.Append("Range of detection is a means of estimating a value that measures searcher effectiveness in a given environment when no scientific data has been collected for effective sweep width in that environment. SAR management uses this value, in planning, to calculate how well a segment will be searched at different track spacings."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Combined with subject visibility, range of detection can be used to calculate the correct team spacing for a target Probability of Detection."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("To learn a little more about Range of Detection, you are welcome to use this slideshow: ");
                    MoreInfoURL = "https://www.sarassist.ca/downloads/RangeofDetection.zip";
                    MoreInfoButtonText = "Download Slideshow";
                    Body = bt.ToString();
                    return true;
                case "UseThisEvaluation":
                    Title = "Use This Mattson Evaluation";
                    bt.Append("Use This Evaluation will direct Incident Command Assistant to use the Mattson Evaluation currently displayed to calculate POA and other related statistics throughout the program.  This evaluation will continue to be used in subsequent operational periods until a new evaluation is selected an applied throughout the program."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append(" Previous evaluations are still saved, and accessible from the dropdown at the top of the Mattson Evaluations screen.To switch which one is used, simply open another and click the Use This Evaluation button.");
                    Body = bt.ToString();
                    return true;
                case "ProportionalMattson":
                    Title = "Proportional Mattson";
                    bt.Append("Determine which region has the highest probability of the subject being there, ignoring the size of the regions. Give this region a reference value of 10. It is okay to have 2 or more regions with a 10 if you think they are the most likely regions to contain the subject and are equally likely."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Then compare the probability of each other region to the first. The value entered for each should be in proportion to the probability of the first region.  For example, if you think a region is ½ as likely to contain the subject as the region given a 10 then give it a 5, if a region is 80% as likely then give it an 8 (no need to go beyond whole numbers)."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It is important that all evaluators use the same scoring system.");
                    Body = bt.ToString();
                    return true;

                case "POA":
                    Title = "Probability of Area";
                    bt.Append("The probability of area is an estimation of the likelihood the subject is in this segment, relative to the others.  For example, if you have two segments defined, and the subject is determined to be as likely to be in one as the other, each will have a POA of 50%."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("POA is typically determined by conducting a Mattson evaluation with a group of people familiar with the area and the subject profile. The calculated POA field will be filled in by adding a Mattson score to this program.  If you prefer to determine POA manually, or by another method, you can use the Manual POA field here. Any value entered there will override any calculated one.  If you no longer wish to use the manual value, set it o 0%.");
                    Body = bt.ToString();
                    return true;
                /* team assignments */
                case "TeamAssignments204":
                    Title = "Team Assignments form (ICS 204)";
                    bt.Append("PURPOSE: Initially created by Planning, the Team Assignment Sheet is used by Operations to assemble and dispatch appropriate resources. The same form is used to record debriefings from the teams so that they can be referenced for future planning."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("PREPARATION: Guided by the IAP, the Planning Section creates and prioritizes assignments for field teams and other resources.Each is approved by the Planning Section Chief.One form for each team assignment with a copy to the team leader.Once completed by Planning, Assignments are sent to Operations who provide a team and the resources required to complete the assignment.Operations provides additional information for the form. The Team Assignment Sheet is used to brief the team before being deployed."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("DISTRIBUTION: A copy should be given to the team leader during briefing and the original retained by Operations."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;
                case "MoveAssignment":
                    Title = "Move Assignment";
                    bt.Append("This tool allows you to move selected assignments from one operational period to another. ");
                    bt.Append("This is most useful for moving unassigned or incomplete assignments forward to a new operational period."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("When assignments are moved, they are automatically re-numbered to the next available assignment numbers in the new operational period."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("This tool will NOT remove assigned team members, clear the saved map, or make any other similar changes.  You will need to make any such changes as needed.");
                    Body = bt.ToString();
                    return true;
                case "CommsTeamStatus":
                    Title = "Logging Team Status";
                    bt.Append("When logging communications, you also have the opportunity to change the team’s current status (when applicable).  There are a number of them to choose from, most corresponding to the phases of a team assignment. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Blue status options such as \"Pre-mission prep\", \"Travel to assignment\", \"Execution\", \"Returning from Assignment\", and \"Post Mission Procedures\" are all considered *active* statuses. Teams in these states will be prioritized on status boards, and members assigned to these teams will not be shown when filtering for \"available members\" while building assignments. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("There are also two special coloured statuses: \"Needs Transport\" and \"Needs Attention\".  These denote a team waiting for action by command, rather than a team reporting information.  These statuses are brightly coloured, and will easily stand out on the status board.  Like the blue statuses above, these teams will be considered *active*."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("\"Planned\" and \"Complete\" are inactive statuses, denoting teams not in the field. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If you are logging communications with a source other than a team (for example, ECC or the tasking agency), status is not relevant, as those groups will never appear on the status board. ");
                    Body = bt.ToString();
                    return true;
                case "NetworkSettings":
                    Title = "Network Settings";
                    bt.Append("This program can be run in a local-area network environment, allowing multiple devices to collaborate on a single task."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Within the network, one computer (and only one) must be designated as the \"server\". This should be whichever computer the task was initially started on, as its data will be sent to all other machines that join.  When you set the computer as the server, its IP address and a port number will be shown – please give this to all other users."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Other computers can connect to the server and download the task information from it. To connect to a computer acting as the server, enter that computer’s IP address and port information."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("You may be prompted to allow Incident Command Assistant to operate through your firewall if you are running one on the local machine.  You must say \"Yes\" for the program to function. ");
                    Body = bt.ToString();
                    return true;
                case "ExportQRString":
                    Title = "Export QR Text";
                    bt.Append("This tool allows you to export the text needed to make unique QR codes for each member currently displayed in the list shown on screen."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("You can use this text in a program like MS Word, or an online label printing tool like Avery Design & Print."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("QR Barcodes generated in this way can then be used wtihin the app to sign members in and out.");
                    Body = bt.ToString();
                    return true;
                case "MemberStatusQRScanner":
                    Title = "Member Sign In QR Scanner";
                    bt.Append("ICA supports signing a member in using a QR code scanner.  This could be a 3rd party product or an app such as BarcodeToPC using a smartphone app."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("To view an individual member's barcode, go to Edit > SAR Team Members and right click on a member. You will have the option to save or print their unique QR code.  This code includes their name, qualifications, and emergency contact info."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Members do not have to be in your system to be scanned successfully.  In fact, this is very valuable for mutual aid scenarios, as it will automatically add the relevant qualificaitons, etc. when you sign in.");
                    Body = bt.ToString();
                    return true;
                case "OptionsDefaultQR":
                    Title = "Listen for QR scanner input by default";
                    bt.Append("If checked, the program will automatically listen for input from a QR code scanner while the Member Status screen is in front."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("This should have no impact on other screens, or on the member status screen unless a member barcode is scanned by an attached QR code scanner.");
                    Body = bt.ToString();
                    return true;
                case "OptionsPrimarySARGroup":
                    Title = "Primary SAR Group";
                    bt.Append("The Primary SAR Group selected here will be used as the default group for new members added via import."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It will also be used to sort members on certain forms, with members of this group being sorted above others."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Finally, if you upload this task to the web-based version of ICA, it will be associated with this group.");
                    Body = bt.ToString();
                    return true;
                case "OptionsCheckinTime":
                    Title = "Check-in Time";
                    bt.Append("This should be the standard check-in interval given to field teams."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Teams will be flagged in red on the Team Status Board if the last communications logged for them is further in the past than this value."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("e.g. if 60 minutes is set here, a team that has not checked in within the last hour will go from blue to red on that status board.");
                    Body = bt.ToString();
                    return true;
                case "OptionsECCCheckinTime":
                    Title = "ECC Check-in Time";
                    bt.Append("If you use the communications log to log calls to the Emergency Coordination Centre (ECC / EMBC in the comms log), a count will be shown at the bottom of the main screen with the time since the last check-in."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("After the ECC Check-in Time set here has elapsed, the time will turn red to indicate a check-in is overdue.  At your option you will also be prompted to check in at that point."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;
                case "OptionsTrustedDevices":
                    Title = "Trusted Devices";
                    bt.Append("Devices listed in the \"Trust Devices\" list will automatically receive task data when it is requsted, without a prompt on the host machine."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It does still require the host machine to have networking enabled. This will speed up the process of connecting multiple computers in the ICP together on a task-by-task basis."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("When a device connects for the first time, you will have an option to \"Trust This Device\" which will add the device's information to this list."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Use the \"Remove Selected Device(s)\" button if you no longer want to trust a device.  Future task download requests from that device will cause a prompt.");
                    Body = bt.ToString();
                    return true;
                case "OptionsDefaultToServer":
                    Title = "Always Start As Server";
                    bt.Append("If this option is selected, whenever ICA starts up it will automatically become a 'server' which other computers can connect to without having to go into network settings"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It is strongly suggested that when using this option, the Task Name and Task Number be set prior to other devices connecting."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;

                case "OptionsDefaultPortNumber":
                    Title = "Port to Use";
                    bt.Append("If this computer is set up as a server, this port number will be used for other computers to connect to it.  The default is 42999 as this port is rarely used by other software."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("This option allows you to change that port in order to overcome limitations within your own network environment.  Firewall exceptions or redirects may be required depending on your setup."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Remember to give the new port to all other users attempting to connect over a local area network, they will need to specify the same port number you do."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Finally, you will need to close and re-start Incident Command Assistant for this change to come into effect if you've already entered network mode."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;

                case "GeoJSONConflicts":
                    Title = "geoJSON Assignment Conflicts";
                    bt.Append("A conflict occurs when two assignments – one here in ICA, and one in the file you’re importing – both share the same assignment number.  For example, there is an assignment here already labelled “101” and an assignment in the file being imported also labelled “10”.  You have several options for dealing with this conflict:"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Import assignments and assign new numbers – in this case the conflicting assignments will be given the next assignment number in sequence in his op period.  So if assignments 101 – 105 already exist, your imported assignment will be numbered 106.  For accuracy and consistency, you should then re-number it in the mapping software used to create the file."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Update Assignments with New Information - For example, if the current assignment in ICA doesn’t have its area recorded, that would be imported from the geoJSON file.  This will not overwrite information already saved in ICA."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Ignore conflicting assignments – in this case, those assignments in the import file that already exist in ICA will be ignored during this import process.");
                    Body = bt.ToString();
                    return true;
                case "GeoJSONImport":
                    Title = "geoJSON Assignment Import";
                    bt.Append("This tool allows you to import Assignment-type items from a www.sartopo.com map, directly into ICA.  Assignments are created automatically using the numbers and other information found in the import file. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("To generate a “geoJSON” file, go to your sartopo map and click Export.For format, select “geoJSON”, and check the assignments you want to import into ICA.Note ICA will not be able to read the “operational period” used in sartopo, so all assignments you import will be brought into the current operational period. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Note, this requires the items be “assignment” type items, such as “Line Assignment”, “Area Assignment” or “Buffer Assignment”.  It will not work with standard lines and polygons. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Note that after you’ve imported the assignments, you can open them up and apply an assignment template within ICA – this will update the assignment description and such, but not the coordinates. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);


                    Body = bt.ToString();
                    return true;

                case "EquipmentSet":
                    Title = "Equipment Sets";
                    bt.Append("Equipment Sets allow you to group any number of equipment items together.  When you’re adding items to a specific task, you can add them individually, or by Set."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("For example, you could create an equipment set that included all of the gear commonly stored on your primary response vehicle (say, some radios, GPSs, an inreach, and an AED).  If that vehicle rolls on the task, you can simply add that equipment set and all of the items within it will be tracked for the task."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("An individual piece of equipment can be in more than one set if desired, and a set can contain lots of varieties of equipment."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("It is not recommended that you use Equipment Sets in place of Equipment Categories.  If you want to group pieces of equipment together because they’re the same kind of thing, use a category. If you want to group pieces of equipment together because they are deployed to a task together, use a Set."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);

                    Body = bt.ToString();
                    return true;

                case "PositionLog":
                    Title = "Position Logs";
                    bt.Append("Purpose: Used to record the activities of an individual unit. Completed logs can provide a basic reference from which to extract information for inclusion in any after - action report."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Preparation: Command staff, Division/Group Supervisors, Strike Team/Task Force Leaders and Unit Leaders.Completed logs are forwarded to supervisors who forward them to the Documentation Unit.Generally one per operational period though the Interview / Investigation Unit can maintain an ongoing log."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Outstanding: You can use the position log to track your progress on completing tasks, using reminders as desired. Incomplete items will be noted when the log is printed."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;
                case "Concat":
                    Title = "Task Package Concat Tool";
                    bt.Append("This tool is designed to take the three PDF reports generated by D4H for EMBC, combine them together into a single PDF, and (at your option) add editable fields you can then fill in order to complete your paperwork."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Note there is a known issue where the signature fields are not shown when the document is printed. This is a default behaviour in the code used to add fields to the PDF, and reinforces a best practice in so far as digital signature data is not captured in a paper printout."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("To use the tool, simply generate the three PDFs from D4H, save them to your computer, and browse to each of them here in the tool."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Press “GO” and choose a file name to save the new combined file."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;
                case "AutoBackup":
                    Title = "Automatic Task Backups";
                    bt.Append("If enabled, this tool will automatically create a duplicate copy of the task's save file every so often.  This duplicate will reside in the task folder along with the original and will have a file name like 'year-month-day hour-minute BACKUP Task tasknumber.xml'."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If something happens to your original file, or you accidentally delete something important, you can either open the most recent backup file and use File... Save As... to save it as a new primary file, or you can use File... Import... to import the element you accidentally deleted.");
                    Body = bt.ToString();
                    return true;
                case "AutoSubFolders":
                    Title = "Automatic Sub-folders";
                    bt.Append("This feature allows you to automatically create a series of folders within the main task folder.  These new folders will be created when the task is first saved on this computer. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("These folders could be used to help standardize the organization of additional files associated with the task, such as GPS track backups, clue photos, and any other folders you commonly use."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("Add as many folder names as you want, with each separated by a comma."); bt.Append(Environment.NewLine);
                    bt.Append("For example: GPS track backup, clue photos, maps, pictures of puppies");
                    Body = bt.ToString();
                    return true;
                case "InternetSync":
                    Title = "Internet Incident Sync";
                    bt.Append("This internet sync tool allows users to collaborate via the internet on an incident in real time. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("HOW TO USE"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("On a computer with the current incident information, click on Network / Internet > Internet Sync, then click on Start a New Sync.  You’ll get an encryption key that looks something like this: 3316b8c8-119a-4075-a952-6425f9e922f7MMpLYYXwbZJCGdxmGCkCRw7uuksIW86oC.  You’ll need to share that key with others if you want them to join you. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("On any other computer, click on Network / Internet > Internet Sync then select Join an Ongoing Sync.  You’ll be asked to provide the encryption key you were given by whomever started the incident sync.  Enter the key, and press OK.  The system will take several seconds to download and unencrypt the incident, then you’re good to go! "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("If you lose internet access at some point, changes will pile up on your computer.  Once you are reconnected to the internet (with the program open), those changes will head into the server and be processed by any other computers.  You’ll also pick up any changes that have been made while you were away. "); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("SECURITY"); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    bt.Append("When you sync data, it is encrypted on your computer using the key shown, and then transmitted to a central server to be stored in a database.  That server is located in Canada and owned by CIFFC. When a request to join a sync is made, the data is transmitted to the new computer still encrypted, then decrypted on the computer using that sync key. At no point is the sever able to read the contents of your incident."); bt.Append(Environment.NewLine); bt.Append(Environment.NewLine);
                    Body = bt.ToString();
                    return true;
                default:
                    return false;


            }


        }


    }
}
