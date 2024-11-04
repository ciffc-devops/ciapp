using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{
    public class ICSFormField
    {
        private int _FormNumber;
        private int _FieldNumber;
        private string _FieldName;
        private string _AdditionalText;
        private string _FieldType;
        private bool _Required;
        private string _Instructions;

        public int FieldNumber { get => _FieldNumber; set => _FieldNumber = value; }
        public string FieldName { get => _FieldName; set => _FieldName = value; }
        public string AdditionalText { get => _AdditionalText; set => _AdditionalText = value; }
        public string FieldType { get => _FieldType; set => _FieldType = value; }
        public bool Required { get => _Required; set => _Required = value; }
        public string Instructions { get => _Instructions; set => _Instructions = value; }
        public string InstructionsWithLineFeed { get { return _Instructions.Replace("\n", Environment.NewLine); } }
        public int FormNumber { get => _FormNumber; set => _FormNumber = value; }
    }
}
