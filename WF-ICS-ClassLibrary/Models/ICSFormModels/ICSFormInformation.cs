using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{
    public class ICSFormInformation
    {
        private int _FormNumber;
        private string _FormName;
        private string _InstructionsURL;
        private string _VideoURL;
        private string _Purpose;
        private string _Preparation;
        private string _Distribution;
        private bool _IsInIAP;
        private List<ICSFormField> _Fields = new List<ICSFormField>();

        public int FormNumber { get => _FormNumber; set => _FormNumber = value; }
        public string FormName { get => _FormName; set => _FormName = value; }
        public string NameWithNumber { get => $"{FormNumber} - {FormName}"; }
        public string InstructionsURL { get => _InstructionsURL; set => _InstructionsURL = value; }
        public string VideoURL { get => _VideoURL; set => _VideoURL = value; }
        public string Purpose { get => _Purpose; set => _Purpose = value; }
        public string Preparation { get => _Preparation; set => _Preparation = value; }
        public string Distribution { get => _Distribution; set => _Distribution = value; }
        public List<ICSFormField> Fields { get => _Fields; set => _Fields = value; }
        public bool IsInIAP { get => _IsInIAP; set => _IsInIAP = value; }
    }
}
