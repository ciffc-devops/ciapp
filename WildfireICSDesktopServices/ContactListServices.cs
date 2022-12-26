using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices
{
    public static class ContactListServices
    {

        public static string createContactsPDF(WFIncident task, int OpPeriod, string createdBy, string createdByTitle, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "ICS 205A - Task " + task.IncidentIdentifier + " - Communications List " + OpPeriod.ToString() + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = "BlankForms/ICS205A-CommunicationsList.pdf";
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));



                    stamper = buildContactsPDF(stamper, task, OpPeriod, createdBy, createdByTitle, flattenPDF);

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }

        private static PdfStamper buildContactsPDF(PdfStamper stamper,  WFIncident task, int OpsPeriod, string createdBy, string createdByTitle, bool flattenPDF)
        {
            OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpsPeriod).First();

            stamper.AcroFields.SetField("1 Incident Name", task.IncidentIdentifier);


            stamper.AcroFields.SetField("Text44", string.Format("{0:yyyy-MMM-dd HH:mm}", currentPeriod.PeriodStart));
            stamper.AcroFields.SetField("Text45", string.Format("{0:yyyy-MMM-dd HH:mm}", currentPeriod.PeriodEnd));
            stamper.AcroFields.SetField("Text48", string.Format("{0:yyyy-MMM-dd HH:mm}", DateTime.Now));
            stamper.AcroFields.SetField("Name", createdBy);
            stamper.AcroFields.SetField("Text46", createdByTitle);

            for (int x = 0; x < task.allContacts.Count && x < 34; x++)
            {
                //
                stamper.AcroFields.SetField("Incident Assigned PositionRow" + (x + 1), task.allContacts[x].OrgAndTitle);
                stamper.AcroFields.SetField("ContactName" + (x + 1), task.allContacts[x].ContactName);
                stamper.AcroFields.SetField("Methods of Contact phone pager cell etcRow" + (x + 1), task.allContacts[x].AllContactMethods);
            }


            if (flattenPDF)
            {
                stamper.FormFlattening = true;
            }

            return stamper;
        }



    }
}
