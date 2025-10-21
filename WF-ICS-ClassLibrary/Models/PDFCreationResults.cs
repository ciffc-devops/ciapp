using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class PDFCreationResults
    {
        public List<byte[]> bytes { get; set; }
        public int TotalPages { get; set; }
        public string path { get; set; }
        public bool Successful { get; set; }
        public string TempPath { get; set; }
        public List<Exception> errors { get; set; } = new List<Exception>();
        public int LastStepReached { get; set; }
        public PDFCreationResults() { }
    }

}
