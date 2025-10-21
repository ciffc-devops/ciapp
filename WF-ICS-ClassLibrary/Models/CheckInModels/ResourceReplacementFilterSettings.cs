using ProtoBuf;
using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace WF_ICS_ClassLibrary.Models
{


    [Serializable]
    [ProtoContract]
    public class ResourceReplacementFilterSettings
    {
        [ProtoMember(1)] public int ResourceVariety { get; set; } = 0;
        [ProtoMember(2)] public string ResourceVarietyName { get; set; } = string.Empty;
        [ProtoMember(3)] public int ReplacementRequirement { get; set; } = 0;
        [ProtoMember(4)] public DateTime MidPoint { get; set; }
        [ProtoMember(5)] public DateTime LastDayAsOf { get; set; } //only view resources who will be timing out as of this date (usually 2 weeks from today)
        [ProtoMember(6)] public DateTime StillInAsOf { get; set; } //Only view resources who are still on incident as of this date (usually today)
        [ProtoMember(7)] public int LastDayIsOrAsOf { get; set; } = 0; //= 0 As Of, 1 = On
    }


}
