using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf.parser;

namespace WildfireICSDesktopServices
{
    public static class PDFExtraTools
    {

        public static PdfStamper AddPDFField(this PdfStamper stamper, string fileName, string adjacentText, string fieldType, int height, int width, string fieldName, int[] instancesOfInterest)
        {
            var t = new MyLocationTextExtractionStrategy(adjacentText);
            StringBuilder sb = new StringBuilder();

            //Parse page 1 of the document above
            using (var r = new PdfReader(fileName))
            {
                var ex = PdfTextExtractor.GetTextFromPage(r, 1, t);
            }

            //Loop through each chunk found
            for (int x = 0; x < t.myPoints.Count; x++)
            {
                if (instancesOfInterest.Contains(x))
                {
                    var p = t.myPoints[x];

                    sb.Append(string.Format("Found text {0} at {1}x{2}", p.Text, p.Rect.Left, p.Rect.Bottom));
                    sb.Append(Environment.NewLine);

                    float adjustedStartX = p.Rect.Left + 5;
                    float adjustedStartY = p.Rect.Bottom - 5;
                    if (fieldType == "MultiLineTextField")
                    {
                        adjustedStartX = p.Rect.Left + 12;
                        adjustedStartY = p.Rect.Bottom - (height - 8);
                    }
                    stamper = stamper.AddFormFieldToExistingPDF(fieldType, adjustedStartX, adjustedStartY, height, width, fieldName + (x + 1));
                }
            }





            return stamper;
        }

        public static PdfStamper AddFormFieldToExistingPDF(this PdfStamper stamper, string fieldType, float x, float y, int height, int width, string fieldName)
        {

            switch (fieldType)
            {
                case "TextField":
                    TextField field = new TextField(stamper.Writer, new iTextSharp.text.Rectangle(x, y, x + width, y + height), fieldName);
                    field.Visibility = TextField.VISIBLE;
                    // add the field here, the second param is the page you want it on         
                    stamper.AddAnnotation(field.GetTextField(), 1);

                    break;
                case "Signature":

                    PdfFormField sigField = PdfFormField.CreateSignature(stamper.Writer);
                    sigField.SetWidget(new iTextSharp.text.Rectangle(x, y, x + width, y + height), PdfAnnotation.HIGHLIGHT_INVERT);
                    sigField.FieldName = fieldName;
                    sigField.SetFieldFlags(PdfAnnotation.FLAGS_PRINT);
                    sigField.SetFieldFlags(PdfFormField.FLAGS_PRINT);

                    // add the field here, the second param is the page you want it on
                    stamper.AddAnnotation(sigField, 1);

                    break;
                case "MultiLineTextField":
                    TextField multilineField = new TextField(stamper.Writer, new iTextSharp.text.Rectangle(x, y, x + width, y + height), fieldName);
                    multilineField.Options = TextField.MULTILINE;
                    // add the field here, the second param is the page you want it on         
                    stamper.AddAnnotation(multilineField.GetTextField(), 1);
                    break;
            }
            return stamper;
        }
        public class RectAndText
        {
            public iTextSharp.text.Rectangle Rect;
            public String Text;
            public RectAndText(iTextSharp.text.Rectangle rect, String text)
            {
                this.Rect = rect;
                this.Text = text;
            }
        }

        public class MyLocationTextExtractionStrategy : LocationTextExtractionStrategy
        {
            //Hold each coordinate
            public List<RectAndText> myPoints = new List<RectAndText>();
            private StringBuilder currentBlock = new StringBuilder();

            //The string that we're searching for
            public String TextToSearchFor { get; set; }

            //How to compare strings
            public System.Globalization.CompareOptions CompareOptions { get; set; }

            public MyLocationTextExtractionStrategy(String textToSearchFor, System.Globalization.CompareOptions compareOptions = System.Globalization.CompareOptions.None)
            {
                this.TextToSearchFor = textToSearchFor;
                this.CompareOptions = compareOptions;
            }

            //Automatically called for each chunk of text in the PDF
            public override void RenderText(TextRenderInfo renderInfo)
            {
                base.RenderText(renderInfo);
                var baseline = renderInfo.GetBaseline();


                string text = renderInfo.GetText();
                currentBlock.Append(text);
                if (TextToSearchFor.Equals(currentBlock.ToString()))
                {

                    var rec = baseline.GetBoundingRectange();

                    var rect = new iTextSharp.text.Rectangle(
                                                      rec.X,
                                                      rec.Y,
                                                      rec.X + rec.Width,
                                                      rec.Y + rec.Height
                                                      );
                    ;
                    this.myPoints.Add(new RectAndText(rect, this.TextToSearchFor));
                    currentBlock.Clear();
                }
                else if (TextToSearchFor.Contains(currentBlock.ToString()))
                {
                    //so far, keep adding stuff
                    return;
                }
                else
                {
                    currentBlock.Clear();
                    currentBlock.Append(text);
                    return;
                }


            }
        }

        public static PdfStamper SetPDFCheckbox(this PdfStamper stamper, string fieldname)
        {
            string[] checkboxstates = stamper.AcroFields.GetAppearanceStates(fieldname);
            if (checkboxstates.Count() > 0)
            {
                stamper.AcroFields.SetField(fieldname, checkboxstates[checkboxstates.Count() - 1]);
            }
            return stamper;
        }

        public static bool MergePDFs(IEnumerable<string> fileNames, string targetPdf, bool flattenPDF = false)
        {
            bool merged = true;
            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                Document document = new Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                PdfReader reader = null;
                try
                {
                    document.Open();
                    foreach (string file in fileNames)
                    {
                        reader = new PdfReader(file);



                        if (reader.AcroForm != null && flattenPDF)
                            reader = new PdfReader(FlattenPdfFormToBytes(reader));



                        pdf.AddDocument(reader);
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    merged = false;
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    if (document != null)
                    {

                        document.Close();
                    }
                }
            }

            return merged;
        }

        private static byte[] FlattenPdfFormToBytes(PdfReader reader)
        {
            var memStream = new MemoryStream();
            var stamper = new PdfStamper(reader, memStream) { FormFlattening = true };
            stamper.Close();
            return memStream.ToArray();
        }
    }

    public class TwoColumnHeaderFooter : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;
        // we will put the final number of pages in a template
        PdfTemplate template;
        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;
        #region Properties
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }
        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }
        private iTextSharp.text.Font _HeaderFont;
        public iTextSharp.text.Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }
        private iTextSharp.text.Font _FooterFont;
        public iTextSharp.text.Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }
        #endregion
        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException)
            {
            }
            catch (System.IO.IOException)
            {
            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            iTextSharp.text.Rectangle pageSize = document.PageSize;
            if (Title != string.Empty)
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 19);
                cb.SetRGBColorFill(50, 50, 200);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetTop(40));
                cb.ShowText(Title);
                cb.EndText();
            }
            if (HeaderLeft + HeaderRight != string.Empty)
            {
                PdfPTable HeaderTable = new PdfPTable(2);
                HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                HeaderTable.TotalWidth = pageSize.Width - 80;
                HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

                PdfPCell HeaderLeftCell = new PdfPCell(new Phrase(8, HeaderLeft, HeaderFont));
                HeaderLeftCell.Padding = 5;
                HeaderLeftCell.PaddingBottom = 8;
                HeaderLeftCell.BorderWidthRight = 0;
                HeaderTable.AddCell(HeaderLeftCell);
                PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
                HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                HeaderRightCell.Padding = 5;
                HeaderRightCell.PaddingBottom = 8;
                HeaderRightCell.BorderWidthLeft = 0;
                HeaderTable.AddCell(HeaderRightCell);
                cb.SetRGBColorFill(0, 0, 0);
                HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(40), pageSize.GetTop(50), cb);
            }
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            int getBottomAmount = 20;

            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            String text = "Page " + pageN + " of ";
            float len = bf.GetWidthPoint(text, 8);
            iTextSharp.text.Rectangle pageSize = document.PageSize;
            cb.SetRGBColorFill(100, 100, 100);
           /*
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(getBottomAmount));
            cb.ShowText(text);
            cb.EndText();
            cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(getBottomAmount));
           */
            cb.BeginText();
            cb.SetFontAndSize(bf, 8);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
            "Printed On " + string.Format("{0:yyyy-MMM-dd HH:mm}", PrintTime),
            pageSize.GetRight(40),
            pageSize.GetBottom(getBottomAmount), 0);
            cb.EndText();
        }
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bf, 8);
            template.SetTextMatrix(0, 0);
            //template.ShowText("" + (writer.PageNumber - 1));
            template.ShowText("" + (writer.PageNumber));
            template.EndText();
        }
    }
}


