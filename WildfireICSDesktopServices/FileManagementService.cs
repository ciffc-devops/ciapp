using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Interfaces;

namespace WildfireICSDesktopServices
{
    public class FileManagementService : IFileAccessServices
    {
        public bool CreateFolder(string pathToFolder)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string pathOfFileToDelete)
        {
            throw new NotImplementedException();
        }

        public bool SaveFile(string destinationPath, bool overwriteExisting)
        {
            throw new NotImplementedException();
        }
    }


    public static class FileAccessClasses
    {
        private static string getFileFromPath(string path)
        {
            string filename = "";
            if (path.Contains("\\"))
            {
                int index = path.LastIndexOf("\\");
                filename = path.Substring(index + 1);
            }
            else { filename = path; }
            return filename;
        }

        public static string getWritablePath(WFIncident CurrentTask)
        {
            string path = null;


            if (!string.IsNullOrEmpty(CurrentTask.DocumentPath) && checkWriteAccess(CurrentTask.DocumentPath))
            {
                path = CurrentTask.DocumentPath;
                try { System.IO.Directory.CreateDirectory(path); }
                catch (IOException) { }

                if (!path.Contains(CurrentTask.TaskNumber))
                {
                    path = System.IO.Path.Combine(path, "Task " + CurrentTask.TaskNumber + " - " + CurrentTask.TaskName);
                    System.IO.Directory.CreateDirectory(path);
                }

            }

            if (!string.IsNullOrEmpty(CurrentTask.FileName) && string.IsNullOrEmpty(path))
            {
                int end = CurrentTask.FileName.LastIndexOf("\\");
                path = CurrentTask.FileName.Substring(0, end);

                if (checkWriteAccess(path, false))
                {
                    //path = System.IO.Path.Combine(path, "Task " + CurrentTask.TaskNumber + " - " + CurrentTask.TaskName);
                    //System.IO.Directory.CreateDirectory(path);
                }
                else { path = null; }

            }

            if (string.IsNullOrEmpty(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path, "SAR ICS Form Helper");
                System.IO.Directory.CreateDirectory(path);
                path = System.IO.Path.Combine(path, "Task " + CurrentTask.TaskNumber + " - " + CurrentTask.TaskName);
                System.IO.Directory.CreateDirectory(path);



                if (!checkWriteAccess(path, false))
                {
                    path = null;
                }
            }
            return path;
        }

        public static string getUniqueFileName(string baseFileName, string path, string ext = "pdf", bool returnPath = true)
        {
            string filename = baseFileName + "." + ext;
            int x = 1;
            string newpath = Path.Combine(path, filename);
            if (!File.Exists(newpath))
            {
                if (returnPath) { return newpath; }
                else { return filename; }
            }
            else
            {
                while (File.Exists(Path.Combine(path, baseFileName + "(" + x + ")." + ext)))
                {
                    x += 1;
                }
                filename = baseFileName + "(" + x + ")." + ext;
                if (returnPath)
                {
                    return Path.Combine(path, baseFileName + "(" + x + ")." + ext);
                }
                else { return filename; }
            }
        }

        public static byte[] concatAndAddContent(List<byte[]> pdfByteContent)
        {
            if (pdfByteContent.Count > 0)
            {
                using (var ms = new MemoryStream())
                {
                    using (var doc = new Document())
                    {
                        using (var copy = new PdfSmartCopy(doc, ms))
                        {
                            doc.Open();

                            //Loop through each byte array
                            foreach (var p in pdfByteContent)
                            {
                                try
                                {
                                    //Create a PdfReader bound to that byte array
                                    using (var reader = new PdfReader(p))
                                    {

                                        //Add the entire document instead of page-by-page
                                        copy.AddDocument(reader);
                                    }
                                }
                                catch (Exception)
                                {

                                }
                            }

                            doc.Close();
                        }
                    }

                    //Return just before disposing
                    return ms.ToArray();
                }
            }
            else { return null; }
        }

        public static bool checkWriteAccess(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
    }
}
