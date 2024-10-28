using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildfireICSDesktopServices.Logging
{
    public class LogService : ILogService
    {
        public string GetLogPath()
        {
            CreateAppDataFolder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "SARAssist");
            //string logFile = System.IO.Path.Combine(specificFolder, "log.txt");

            return specificFolder;
        }
        private static void CreateAppDataFolder()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "SARAssist");
            if (!System.IO.Directory.Exists(specificFolder))
            {
                System.IO.Directory.CreateDirectory(specificFolder);
            }

        }

        public void Log(string message)
        {
            CreateAppDataFolder();
            DeleteOldLogFiles();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "SARAssist");
            string logFileName = "CIAPPLog" + DateTime.Now.ToString("yyyyMM") + ".txt";
            string logFile = System.IO.Path.Combine(specificFolder, logFileName);
            try
            {
                System.IO.File.AppendAllText(logFile, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message + Environment.NewLine);

            }
            catch
            {

            }
        }

        public void DeleteOldLogFiles()
        {
            DateTime today = DateTime.Now;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = System.IO.Path.Combine(folder, "SARAssist");
            if (System.IO.Directory.Exists(specificFolder))
            {

                var files = Directory.GetFiles(specificFolder);
                foreach (var file in files)
                {
                    var fileDate = File.GetLastWriteTime(file);
                    if (fileDate < today.AddMonths(-2))
                    {
                        File.Delete(file);
                    }
                }


            }
        }
    }
}
