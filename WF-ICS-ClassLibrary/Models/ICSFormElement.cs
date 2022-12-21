using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    /*********************************************
     * These are the general types used to define an ICS form
     * They will correspond 1:1 with a PDF document to be filled by the app
     **********************************************/


    public class ICSFormElement
    {
        private Guid _ID;
        private string _FieldName;
        private string _PDFFieldName;
        private int _FieldType; //0 = string, 1 = checkbox

        public ICSFormElement() { }

        public Guid ID { get => _ID; set => _ID = value; }
        public string FieldName { get => _FieldName; set => _FieldName = value; }
        public string PDFFieldName { get => _PDFFieldName; set => _PDFFieldName = value; }  
        public int FieldType { get => _FieldType; set => _FieldType = value; }  
    }

    public class ICSForm
    {
        private Guid _ID;
        private string _FormName;
        private int _FormNumber;
        private List<ICSFormElement> _elements;

        public ICSForm() { _elements = new List<ICSFormElement>(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public string FormName { get => _FormName; set => _FormName = value; }
        public int FormNumber { get => _FormNumber; set => _FormNumber = value; }
    }
}
