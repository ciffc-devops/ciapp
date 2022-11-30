using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract]
    [Serializable]
    public class ShortcutButtonOption
    {
        [ProtoMember(1)] public Guid ShortcutID { get; set; }
        public string ShortcutText
        {
            get
            {
                switch (CommandName)
                {
                    case "TeamAssignments": return "Team Assignments";
                    case "NewAssignment": return "New Team Assignment";
                    case "OpsDash": return "Operations Dashboard";
                    case "PlansDash": return "Planning Dashboard";
                    case "AddComms": return "Log Comms";
                    case "ViewComms": return "Open Comms Log";
                    case "AddClue": return "Add Clue";
                    case "ViewClues": return "View Clues";
                    case "SignInMember": return "Sign In Member";
                    case "BulkSignInMember": return "Bulk Sign In Members";
                    case "MemberStatus": return "Member Status Board";
                    case "ViewEquipment": return "View Equipment";
                    case "AddNote": return "Add a Note";
                    case "ViewNotes": return "View Notes";

                    default:
                        return null;
                }
            }
        }
        [ProtoMember(2)] public int Position { get; set; }
        [ProtoMember(3)] public string CommandName { get; set; }

        public ShortcutButtonOption() { ShortcutID = Guid.NewGuid(); }
        public ShortcutButtonOption(string command) { CommandName = command; ShortcutID = Guid.NewGuid(); }
    }

    public class ShortcutButtonEventArgs : EventArgs
    {
        public ShortcutButtonOption ShortcutOption { get; set; }
        public ShortcutButtonEventArgs() { }
        public ShortcutButtonEventArgs(ShortcutButtonOption option) { ShortcutOption = option; }
    }
}
